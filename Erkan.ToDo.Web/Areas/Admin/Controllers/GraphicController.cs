using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Erkan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class GraphicController : Controller
    {
        private readonly IAppUserService _appUserService;

        public GraphicController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Graphic;
            return View();
        }

        public IActionResult MostCompleted()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.GetMostCompletedStaff());
            return Json(jsonString);
        }
        public IActionResult MostWorking()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.GetMostWorkingStaff());
            return Json(jsonString);
        }

    }
}
