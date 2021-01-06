using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IReportService _reportService;

        public HomeController(ITaskService taskService, INotificationService notificationService, UserManager<AppUser> userManager, IReportService reportService)
        {
            _taskService = taskService;
            _notificationService = notificationService;
            _userManager = userManager;
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);

            TempData["Active"] = "home";

            ViewBag.UnAssignedTask = _taskService.GetUnAssignedTask();

            ViewBag.CompletedTask = _taskService.GetCompletedTask();            

            ViewBag.Notification = _notificationService.GetUnreadCountByAppUserId(user.Id);

            ViewBag.ReportCount = _reportService.GetReportCount();

            return View();
        }
    }
}
