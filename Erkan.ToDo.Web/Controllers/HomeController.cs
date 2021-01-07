using Erkan.ToDo.DTO.DTOs.AppUserDtos;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.BaseControllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Controllers
{
    public class HomeController : BaseIdentityController
    {
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager):base(userManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserSignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await GetSignInUser();
                if (user!=null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(model.UserName,model.Password, model.RememberMe, false);
                    if (identityResult.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                        
                    }
                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }
            return View("Index",model);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(AppUserAddDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Name = model.Name,
                    SurName = model.Surname,
                    Email = model.Email,
                    UserName = model.UserName
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, "Member");
                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    ErrorAdd(addRoleResult.Errors);
                }
                ErrorAdd(result.Errors);
            }

            return View(model);
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
