using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Erkan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TaskController : Controller
    {
       private readonly ITaskService _taskService;
        private readonly IImportanceService _importanceService;

        public TaskController(ITaskService taskService, IImportanceService importanceService)
        {
            _taskService = taskService;
            _importanceService = importanceService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "task";
            List<Task> tasks = _taskService.GetByImportanceIncomplete();
            List<TaskListViewModel> models = new List<TaskListViewModel>();
            foreach (var item in tasks)
            {
                TaskListViewModel model = new TaskListViewModel
                {
                    CreatedDate = item.CreatedDate,
                    Explanation = item.Explanation,
                    Importance = item.Importance,
                    Id = item.Id,
                    ImportanceId = item.ImportanceId,
                    Name = item.Name,
                    Statement = item.Statement
                };
                models.Add(model);
            }
            return View(models);
        }
        public IActionResult AddTask()
        {
            TempData["Active"] = "task";
            ViewBag.Importances =new SelectList( _importanceService.GetAll(), "Id", "Definition");
            return View(new TaskAddViewModel());
        }
        [HttpPost]
        public IActionResult AddTask(TaskAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _taskService.Save(new Task
                {
                    Explanation = model.Explanation,
                    Name = model.Name,
                    ImportanceId = model.ImportanceId
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult UpdateTask(int id)
        {
            TempData["Active"] = "task";
            var task = _taskService.GetId(id);
            TaskUpdateViewModel model = new TaskUpdateViewModel
            {
                Id = task.Id,
                Explanation = task.Explanation,
                ImportanceId = task.ImportanceId,
                Name = task.Name
            };
            ViewBag.Importances = new SelectList(_importanceService.GetAll(), "Id", "Definition",task.ImportanceId);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateTask(TaskUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _taskService.Update(new Task()
                {
                    Id = model.Id,
                    Explanation = model.Explanation,
                    ImportanceId = model.ImportanceId,
                    Name = model.Name

                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult DeleteTask(int id)
        {
            _taskService.Delete(new Task { Id = id });
            return Json(null);
        }
    }
}
