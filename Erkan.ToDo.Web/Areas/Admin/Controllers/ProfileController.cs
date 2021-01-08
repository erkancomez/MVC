using AutoMapper;
using Erkan.ToDo.DTO.DTOs.AppUserDtos;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.BaseControllers;
using Erkan.ToDo.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class ProfileController : BaseIdentityController
    {
        private readonly IMapper _mapper;

        public ProfileController(UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Profile;

            return View(_mapper.Map<AppUserListDto>(await GetSignInUser()));
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDto model, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                var updateUser = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
                if (picture != null)
                {
                    string extension = Path.GetExtension(picture.FileName);
                    string pictureName = Guid.NewGuid() + extension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + pictureName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await picture.CopyToAsync(stream);
                    }

                    updateUser.Picture = pictureName;
                }
                updateUser.Email = model.Email;
                updateUser.Name = model.Name;
                updateUser.SurName = model.SurName;

                _mapper.Map<AppUserListDto>(updateUser);

                var result = await _userManager.UpdateAsync(updateUser);
                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işlemi başarıyla gerçekleşti";
                    return RedirectToAction("Index");
                }
                else
                {
                    ErrorAdd(result.Errors);
                }
            }
            return View(model);
        }
    }
}

