using Erkan.ToDo.Web.CustomFilters;
using Erkan.ToDo.Web.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
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

            //SetCookie();
            SetSession();
            ViewBag.Cookie = GetSession();

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
        [NamecantErkan]
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
            return View("SignUp", model);
        }
        public void SetCookie()
        {
            HttpContext.Response.Cookies.Append("person", "erkan", new Microsoft.AspNetCore.Http.CookieOptions()
            {
                Expires = DateTime.Now.AddDays(20),
                HttpOnly = true,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
                Secure = false
            });

        }
        public string GetCookie()
        {
            return HttpContext.Request.Cookies["person"];
        }
        public void SetSession()
        {
            HttpContext.Session.SetString("person", "Erkan");
        }
        public string GetSession()
        {
            return HttpContext.Session.GetString("person");
        }
        public IActionResult PageError(int code)
        {
            @ViewBag.Code = code;
            if (code == 404)
            {
                ViewBag.Message = "Sayfa Bulunamadı";
            }
            return View();
        }
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature =
                HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.Path = exceptionHandlerPathFeature.Path;
            ViewBag.Message = exceptionHandlerPathFeature.Error.Message;
            return View();
        }
        public IActionResult Hata()
        {
            throw new Exception("Hata oluştu");
        }
    }
}
