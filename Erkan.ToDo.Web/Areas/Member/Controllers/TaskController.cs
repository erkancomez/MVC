using AutoMapper;
using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DTO.DTOs.TaskDtos;
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
    public class TaskController : BaseIdentityController
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;


        public TaskController(ITaskService taskService, UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int activePage=1)
        {
            TempData["Active"] = "task";
            var user = await GetSignInUser();
            var tasks =_mapper.Map<List<TaskListAllDto>>(_taskService.GetAllTableInCompleted(out int totalPage, user.Id, activePage));

            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;

            return View(tasks);
        }
    }
}
