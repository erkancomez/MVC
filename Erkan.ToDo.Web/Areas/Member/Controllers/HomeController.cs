using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class HomeController : Controller
    {
        private readonly IReportService _reportService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITaskService _taskService;
        private readonly INotificationService _notificationService;

        public HomeController(IReportService reportService, UserManager<AppUser> userManager, ITaskService taskService, INotificationService notificationService)
        {
            _reportService = reportService;
            _userManager = userManager;
            _taskService = taskService;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.ReportCount = _reportService.GetReportCountByAppUserId(user.Id);

            ViewBag.CompletedTaskCount = _taskService.GetCompletedTaskCountByUserId(user.Id);

            ViewBag.IncompletedTaskCount = _taskService.GetIncompletedTaskCountByUserId(user.Id);

            ViewBag.UnreadNotification = _notificationService.GetUnreadCountByAppUserId(user.Id);

            TempData["Active"] = "home";
            return View();
        }
    }
}
