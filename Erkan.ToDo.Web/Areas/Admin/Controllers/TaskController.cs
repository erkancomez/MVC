using AutoMapper;
using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DTO.DTOs.TaskDtos;
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
        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IImportanceService importanceService, IMapper mapper)
        {
            _taskService = taskService;
            _importanceService = importanceService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "task";
        
            return View(_mapper.Map<List<TaskListDto>>(_taskService.GetByImportanceIncomplete()));
        }
        public IActionResult AddTask()
        {
            TempData["Active"] = "task";
            ViewBag.Importances =new SelectList( _importanceService.GetAll(), "Id", "Definition");
            return View(new TaskAddDto());
        }
        [HttpPost]
        public IActionResult AddTask(TaskAddDto model)
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
            ViewBag.Importances = new SelectList(_importanceService.GetAll(), "Id", "Definition");
            return View(model);
        }
        public IActionResult UpdateTask(int id)
        {
            TempData["Active"] = "task";
           var gorev =  _taskService.GetId(id);


            ViewBag.Importances = new SelectList(_importanceService.GetAll(), "Id", "Definition", gorev.ImportanceId);
            return View(_mapper.Map<TaskUpdateDto>(gorev));
        }
        [HttpPost]
        public IActionResult UpdateTask(TaskUpdateDto model)
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
            ViewBag.Importances = new SelectList(_importanceService.GetAll(), "Id", "Definition", model.ImportanceId);
            return View(model);
        }
        public IActionResult DeleteTask(int id)
        {
            _taskService.Delete(new Task { Id = id });
            return Json(null);
        }
    }
}
