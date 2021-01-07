using AutoMapper;
using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DTO.DTOs.NotificationDtos;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.BaseControllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class NotificationController : BaseIdentityController
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "notification";
            var user = await GetSignInUser();

            return View(_mapper.Map<List<NotificationListDto>>(_notificationService.GetUnread(user.Id)));
        }
        [HttpPost]
        public IActionResult Index(int id)
        {
            TempData["Active"] = "workorder";
            var updateNotification = _notificationService.GetId(id);
            updateNotification.Statement = true;
            _notificationService.Update(updateNotification);
            return RedirectToAction("Index");
        }
    }
}
