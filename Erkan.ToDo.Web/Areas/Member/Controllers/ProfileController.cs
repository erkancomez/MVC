using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "profile";
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserListViewModel model = new AppUserListViewModel
            {
                Id = appUser.Id,
                Name = appUser.Name,
                Email = appUser.Email,
                SurName = appUser.SurName,
                Picture = appUser.Picture
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListViewModel model, IFormFile picture)
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

                updateUser.Name = model.Name;
                updateUser.SurName = model.SurName;
                updateUser.Email = model.Email;

                var result = await _userManager.UpdateAsync(updateUser);
                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işlemi başarıyla gerçekleşti";
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }
        //[HttpPost]
        //public async Task<IActionResult> Index(AppUserListViewModel model, IFormFile picture)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var guncellencekKullanici = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
        //        if (picture != null)
        //        {
        //            string uzanti = Path.GetExtension(picture.FileName);
        //            string resimAd = Guid.NewGuid() + uzanti;
        //            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + resimAd);
        //            using (var stream = new FileStream(path, FileMode.Create))
        //            {
        //                await picture.CopyToAsync(stream);
        //            }

        //            guncellencekKullanici.Picture = resimAd;
        //        }

        //        guncellencekKullanici.Name = model.Name;
        //        guncellencekKullanici.SurName = model.SurName;
        //        guncellencekKullanici.Email = model.Email;

        //        var result = await _userManager.UpdateAsync(guncellencekKullanici);
        //        if (result.Succeeded)
        //        {
        //            TempData["message"] = "Güncelleme işleminiz başarı ile gerçekleşti";
        //            return RedirectToAction("Index");
        //        }

        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError("", item.Description);
        //        }
        //    }
        //    return View(model);
        //}
    }
}

