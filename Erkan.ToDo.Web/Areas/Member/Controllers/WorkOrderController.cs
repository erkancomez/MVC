using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Web.Areas.Admin.Models;
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

        public WorkOrderController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult Index(int id)
        {
            TempData["Active"] = "workOrder";
            var tasks = _taskService.GetAllTable(I => I.AppUserId == id && !I.Statement);

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
    }
}
