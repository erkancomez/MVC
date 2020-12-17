using Erkan.ToDo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Isim = "Erkan";
            TempData["Isim"] = "Erkan";
            ViewData["Isim"] = "Erkan";

            return View();
        }
        public IActionResult Sonuc()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp2(UserSignUpViewModel model)
        {
            //string name = HttpContext.Request.Form["Name"].ToString();
            //ViewBag.Name = name;
            if (ModelState.IsValid)
            {

            }
            ModelState.AddModelError(nameof(UserSignUpViewModel.Name), "Name Area");
            ModelState.AddModelError("", "eroor for model");
            return View("SignUp",model);
        }
    }
}
