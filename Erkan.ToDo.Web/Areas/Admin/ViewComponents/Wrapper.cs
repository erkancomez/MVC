using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public Wrapper(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {

            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            AppUserListViewModel model = new AppUserListViewModel
            {
                Id = user.Id,
                Name = user.Name,
                SurName = user.SurName,
                Picture = user.Picture,
                Email = user.Email
            };



            return View(model);
        }
    }
}
