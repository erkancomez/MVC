using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Erkan.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WorkOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly ITaskService _taskService;
        private readonly UserManager<AppUser> _userManager;

        public WorkOrderController(IAppUserService appUserService, ITaskService taskService, UserManager<AppUser> userManager)
        {
            _appUserService = appUserService;
            _taskService = taskService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "workorder";
            //var model = _appUserService.GetNonAdmin();

            List<Task> tasks = _taskService.GetAllTable();
            List<TaskListAllViewModel> models = new List<TaskListAllViewModel>();

            foreach (var item in tasks)
            {
                TaskListAllViewModel model = new TaskListAllViewModel
                {
                    Id = item.Id,
                    Explanation = item.Explanation,
                    Importance = item.Importance,
                    Name = item.Name,
                    AppUser = item.AppUser,
                    CreatedDate = item.CreatedDate,
                    Reports = item.Reports
                };
                models.Add(model);


            }
            return View(models);
        }

        public IActionResult Detail(int id)
        {
            TempData["Active"] = "workorder";
            var task = _taskService.GetByTaskId(id);
            TaskListAllViewModel model = new TaskListAllViewModel
            {
                Reports = task.Reports,
                Name = task.Name,
                Explanation = task.Explanation,
                AppUser = task.AppUser
            };

            return View(model);

        }

        public IActionResult AssignStaff(int id, string s, int page = 1)
        {
            TempData["Active"] = "workorder";

            ViewBag.ActivePage = page;

            ViewBag.Search = s;

            var task = _taskService.GetImportanceById(id);
            var staffs = _appUserService.GetNonAdmin(out int totalPage, s, page);

            ViewBag.TotalPage = totalPage;

            List<AppUserListViewModel> appUserListModel = new List<AppUserListViewModel>();
            foreach (var item in staffs)
            {
                AppUserListViewModel model = new AppUserListViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    SurName = item.SurName,
                    Email = item.Email,
                    Picture = item.Picture
                };
                appUserListModel.Add(model);
            }
            ViewBag.Staffs = appUserListModel;

            TaskListViewModel taskModel = new TaskListViewModel
            {
                Id = task.Id,
                Name = task.Name,
                Explanation = task.Explanation,
                Importance = task.Importance,
                CreatedDate = task.CreatedDate
            };
            return View(taskModel);
        }
        [HttpPost]
        public IActionResult AssignStaff(StaffTaskViewModel model)
        {
            var updateTask = _taskService.GetId(model.TaskId);
            updateTask.AppUserId = model.StaffId;

            _taskService.Update(updateTask);
            return RedirectToAction("Index");
        }

        public IActionResult TaskStaff(StaffTaskViewModel model)
        {
            TempData["Active"] = "workorder";
            var user = _userManager.Users.FirstOrDefault(I => I.Id == model.StaffId);
            var task = _taskService.GetImportanceById(model.TaskId);

            AppUserListViewModel userModel = new AppUserListViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Picture = user.Picture,
                SurName = user.SurName
            };
            userModel.Email = userModel.Email;

            TaskListViewModel taskModel = new TaskListViewModel
            {
                Id = task.Id,
                Explanation = task.Explanation,
                Importance = task.Importance,
                Name = task.Name
            };

            StaffTaskListViewModel staffTaskModel = new StaffTaskListViewModel
            {
                AppUser = userModel,
                Task = taskModel
            };

            return View(staffTaskModel);
        }
    }
}
