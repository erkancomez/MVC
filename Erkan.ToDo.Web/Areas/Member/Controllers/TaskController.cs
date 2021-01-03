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

namespace Erkan.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly UserManager<AppUser> _userManager;

        public TaskController(ITaskService taskService, UserManager<AppUser> userManager)
        {
            _taskService = taskService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int activePage=1)
        {
            TempData["Active"] = "task";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            int totalPage;
            var tasks = _taskService.GetAllTableInCompleted(out totalPage, user.Id, activePage);

            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;

            List<TaskListAllViewModel> models = new List<TaskListAllViewModel>();
            foreach (var task in tasks)
            {
                TaskListAllViewModel model = new TaskListAllViewModel {
                    Id = task.Id,
                    Explanation = task.Explanation,
                    Importance = task.Importance,
                    AppUser = task.AppUser,
                    CreatedDate = task.CreatedDate,
                    Name = task.Name,
                    Reports = task.Reports
                };

                models.Add(model);

            }

            return View(models);
        }
    }
}
