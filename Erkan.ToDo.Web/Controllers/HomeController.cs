using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ITaskService taskService, UserManager<AppUser> userManager)
        {
            _taskService = taskService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(AppUserAddViewModel model)
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
                        return RedirectToAction("SignIn");
                    }
                    foreach (var item in addRoleResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(model);
        }
    }
}
