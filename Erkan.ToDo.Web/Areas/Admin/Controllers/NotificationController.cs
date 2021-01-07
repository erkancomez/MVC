using AutoMapper;
using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DTO.DTOs.NotificationDtos;
using Erkan.ToDo.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _notificationService = notificationService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "notification";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

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
