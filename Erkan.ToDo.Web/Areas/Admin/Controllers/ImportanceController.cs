using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ImportanceController : Controller
    {
        private readonly IImportanceService _importanceService;

        public ImportanceController(IImportanceService importanceService)
        {
            _importanceService = importanceService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "importance";
            List<Importance> importances = _importanceService.GetAll();

            List<ImportanceListViewModel> model = new List<ImportanceListViewModel>();

            foreach (var item in importances)
            {
                ImportanceListViewModel importanceModel = new ImportanceListViewModel
                {
                    Id = item.Id,
                    Definition = item.Definition
                };

                model.Add(importanceModel);
            }
            return View(model);
        }
        public IActionResult AddImportance()
        {
            TempData["Active"] = "importance";
            return View(new ImportanceAddViewModel());
        }
        [HttpPost]
        public IActionResult AddImportance(ImportanceAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _importanceService.Save(new Importance() {
                Definition = model.Definition
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult UpdateImportance(int id)
        {
            TempData["Active"] = "importance";
            var importance = _importanceService.GetId(id);
            ImportanceUpdateViewModel model = new ImportanceUpdateViewModel
            { 
                Id = importance.Id, Definition = importance.Definition 
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateImportance(ImportanceUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _importanceService.Update(new Importance
                {
                    Id = model.Id,
                    Definition = model.Definition
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
