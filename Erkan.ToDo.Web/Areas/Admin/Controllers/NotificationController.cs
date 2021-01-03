using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;

        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager)
        {
            _notificationService = notificationService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "notification";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var notifications = _notificationService.GetUnread(user.Id);

            List<NotificationListViewModel> models = new List<NotificationListViewModel>();
            foreach (var item in notifications)
            {
                NotificationListViewModel model = new NotificationListViewModel
                {
                    Id = item.Id,
                    Explanation = item.Explanation

                };
                models.Add(model);

            }

            return View(models);
        }
        [HttpPost]
        public IActionResult Index(int id)
        {
            TempData["Active"] = "workorder";
            var updateNotification = _notificationService.GetId(id);
            updateNotification.Statement = true;
            _notificationService.Update(updateNotification);
            return RedirectToAction("Index");
        }
    }
}
