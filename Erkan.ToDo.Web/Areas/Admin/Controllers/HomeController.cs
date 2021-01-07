using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.BaseControllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class HomeController : BaseIdentityController
    {
        private readonly ITaskService _taskService;
        private readonly INotificationService _notificationService;
        private readonly IReportService _reportService;

        public HomeController(ITaskService taskService, INotificationService notificationService, UserManager<AppUser> userManager, IReportService reportService) : base(userManager)
        {
            _taskService = taskService;
            _notificationService = notificationService;
            _reportService = reportService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetSignInUser();

            TempData["Active"] = "home";

            ViewBag.UnAssignedTask = _taskService.GetUnAssignedTask();

            ViewBag.CompletedTask = _taskService.GetCompletedTask();            

            ViewBag.Notification = _notificationService.GetUnreadCountByAppUserId(user.Id);

            ViewBag.ReportCount = _reportService.GetReportCount();

            return View();
        }
    }
}
