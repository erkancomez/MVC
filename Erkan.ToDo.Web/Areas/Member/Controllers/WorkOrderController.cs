using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class WorkOrderController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IReportService _reportService;

        public WorkOrderController(ITaskService taskService, UserManager<AppUser> userManager, IReportService reportService)
        {
            _taskService = taskService;
            _userManager = userManager;
            _reportService = reportService;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "workOrder";

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var tasks = _taskService.GetAllTable(I => I.AppUserId == user.Id && !I.Statement);

            List<TaskListAllViewModel> models = new List<TaskListAllViewModel>();

            foreach (var item in tasks)
            {
                TaskListAllViewModel model = new TaskListAllViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Importance = item.Importance,
                    Explanation = item.Explanation,
                    CreatedDate = item.CreatedDate,
                    AppUser = item.AppUser,
                    Reports = item.Reports
                };

                models.Add(model);
            }

            return View(models);
        }

        public IActionResult AddReport(int id)
        {
            TempData["Active"] = "workOrder";
            var task = _taskService.GetImportanceById(id);

            ReportAddViewModel model = new ReportAddViewModel
            {
                TaskId = id,
                Task = task
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddReport(ReportAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Save(new Report
                {
                    TaskId = model.TaskId,
                    Describtion = model.Describtion,
                    Detail = model.Detail

                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateReport(int id)
        {
            TempData["Active"] = "workOrder";
            var report = _reportService.GetByTaskId(id);
            ReportUpdateViewModel model = new ReportUpdateViewModel
            {
                Id = report.Id,
                TaskId = report.TaskId,
                Task = report.Task,
                Describtion = report.Describtion,
                Detail = report.Detail
            };


            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateReport(ReportUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var updateReport = _reportService.GetId(model.Id);

                updateReport.Describtion = model.Describtion;
                updateReport.Detail = model.Detail;

                _reportService.Update(updateReport);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult CompleteTask(int taskId)
        {
            var updatetask = _taskService.GetId(taskId);
            updatetask.Statement = true;
            _taskService.Update(updatetask);
            return Json(null);
        }

    }

}
