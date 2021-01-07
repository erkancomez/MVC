using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.BaseControllers;
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
    public class HomeController : BaseIdentityController
    {
        private readonly IReportService _reportService;
        private readonly ITaskService _taskService;
        private readonly INotificationService _notificationService;

        public HomeController(IReportService reportService, UserManager<AppUser> userManager, ITaskService taskService, INotificationService notificationService):base(userManager)
        {
            _reportService = reportService;
            _taskService = taskService;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetSignInUser();
            ViewBag.ReportCount = _reportService.GetReportCountByAppUserId(user.Id);

            ViewBag.CompletedTaskCount = _taskService.GetCompletedTaskCountByUserId(user.Id);

            ViewBag.IncompletedTaskCount = _taskService.GetIncompletedTaskCountByUserId(user.Id);

            ViewBag.UnreadNotification = _notificationService.GetUnreadCountByAppUserId(user.Id);

            TempData["Active"] = "home";
            return View();
        }
    }
}
