﻿using AutoMapper;
using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DTO.DTOs.AppUserDtos;
using Erkan.ToDo.DTO.DTOs.ReportDtos;
using Erkan.ToDo.DTO.DTOs.TaskDtos;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.BaseControllers;
using Erkan.ToDo.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Erkan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class WorkOrderController : BaseIdentityController
    {
        private readonly IAppUserService _appUserService;
        private readonly ITaskService _taskService;

        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public WorkOrderController(IAppUserService appUserService, ITaskService taskService, UserManager<AppUser> userManager, IFileService fileService, INotificationService notificationService, IMapper mapper) : base(userManager)
        {
            _appUserService = appUserService;
            _taskService = taskService;
            _fileService = fileService;
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.WorkOrder;

            return View(_mapper.Map<List<TaskListAllDto>>(_taskService.GetAllTable()));
        }

        public IActionResult Detail(int id)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;
            

            return View(_mapper.Map<TaskListAllDto>(_taskService.GetByTaskId(id)));

        }

        public IActionResult GetExcel(int id)
        {
            return File(_fileService.TransferExcel(_mapper.Map<List<ReportFileDto>>(_taskService.GetByTaskId(id).Reports)), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }

        public IActionResult GetPdf(int id)
        {
            var path = _fileService.TranferPdf(_mapper.Map<List<ReportFileDto>>(_taskService.GetByTaskId(id).Reports));

            return File(path, "aplication/pdf", Guid.NewGuid() + ".pdf");
        }

        public IActionResult AssignStaff(int id, string s, int page = 1)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;

            ViewBag.ActivePage = page;

            ViewBag.Search = s;

            var staffs = _mapper.Map<List<AppUserListDto>>(_appUserService.GetNonAdmin(out int totalPage, s, page));
            ViewBag.TotalPage = totalPage;

            ViewBag.Staffs = staffs;

            return View(_mapper.Map<TaskListDto>(_taskService.GetImportanceById(id)));
        }
        [HttpPost]
        public IActionResult AssignStaff(StaffTaskDto model)
        {
            var updateTask = _taskService.GetId(model.TaskId);
            updateTask.AppUserId = model.StaffId;

            _taskService.Update(updateTask);

            _notificationService.Save(new Notification
            {
                AppUserId = model.StaffId,
                Explanation= $"'{updateTask.Name}' adlı iş için görevlendirildiniz."
            });
            return RedirectToAction("Index");
        }

        public IActionResult TaskStaff(StaffTaskDto model)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;

            StaffTaskListDto staffTaskModel = new StaffTaskListDto
            {
                AppUser = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(I => I.Id == model.StaffId)),
                Task = _mapper.Map<TaskListDto>(_taskService.GetImportanceById(model.TaskId))
            };

            return View(staffTaskModel);
        }
    }
}
