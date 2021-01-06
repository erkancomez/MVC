using Erkan.ToDo.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class GraphicController : Controller
    {
        private readonly IAppUserService _appUserService;

        public GraphicController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "graphic";
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
