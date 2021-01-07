using AutoMapper;
using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DTO.DTOs.ReportDtos;
using Erkan.ToDo.DTO.DTOs.TaskDtos;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.BaseControllers;
using Erkan.ToDo.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class WorkOrderController : BaseIdentityController
    {
        private readonly ITaskService _taskService;
        private readonly IReportService _reportService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public WorkOrderController(ITaskService taskService, UserManager<AppUser> userManager, IReportService reportService, INotificationService notificationService, IMapper mapper):base(userManager)
        {
            _taskService = taskService;
            _reportService = reportService;
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.WorkOrder;

            var user = await GetSignInUser();

            return View(_mapper.Map<List<TaskListAllDto>>(_taskService.GetAllTable(I => I.AppUserId == user.Id && !I.Statement)));
        }

        public IActionResult AddReport(int id)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;
            var task = _taskService.GetImportanceById(id);

            ReportAddDto model = new ReportAddDto
            {
                TaskId = id,
                Task = task
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReportAsync(ReportAddDto model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Save(new Report
                {
                    TaskId = model.TaskId,
                    Describtion = model.Describtion,
                    Detail = model.Detail

                });

                var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");

                var activeUser = await GetSignInUser();

                foreach (var admin in adminUserList)
                {
                    _notificationService.Save(new Notification
                    {
                        Explanation = $"{activeUser.Name} {activeUser.SurName} yeni bir rapor yazdı.",
                        AppUserId = admin.Id
                    });
                }


                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateReport(int id)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;
            var report = _reportService.GetByTaskId(id);
            ReportUpdateDto model = new ReportUpdateDto
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
        public IActionResult UpdateReport(ReportUpdateDto model)
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

        public async Task<IActionResult> CompleteTaskAsync(int taskId)
        {
            var updatetask = _taskService.GetId(taskId);
            updatetask.Statement = true;
            _taskService.Update(updatetask);

            var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");

            var activeUser = await GetSignInUser();

            foreach (var admin in adminUserList)
            {
                _notificationService.Save(new Notification
                {
                    Explanation = $"{activeUser.Name} {activeUser.SurName} vermiş olduğunuz bir görevi tamamladı.",
                    AppUserId = admin.Id
                });
            }

            return Json(null);
        }

    }

}
