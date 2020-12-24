using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.Controllers
{
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
            List<Importance> importances = _importanceService.GetAll();

            List<ImportanceListViewModel> model = new List<ImportanceListViewModel>();

            foreach (var item in importances)
            {
                ImportanceListViewModel importanceModel = new ImportanceListViewModel();
                importanceModel.Id = item.Id;
                importanceModel.Definition = item.Definition;

                model.Add(importanceModel);
            }
            return View(model);
        }
    }
}
