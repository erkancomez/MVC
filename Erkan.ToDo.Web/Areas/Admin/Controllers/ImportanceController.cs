using AutoMapper;
using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DTO.DTOs.ImportanceDtos;
using Erkan.ToDo.Entities.Concrete;
using Erkan.ToDo.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Erkan.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class ImportanceController : Controller
    {
        private readonly IImportanceService _importanceService;
        private readonly IMapper _mapper;

        public ImportanceController(IImportanceService importanceService, IMapper mapper)
        {
            _importanceService = importanceService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Importance;

            return View(_mapper.Map<List<ImportanceListDto>>(_importanceService.GetAll()));
        }
        public IActionResult AddImportance()
        {
            TempData["Active"] = TempDataInfo.Importance;
            return View(new ImportanceAddDto());
        }
        [HttpPost]
        public IActionResult AddImportance(ImportanceAddDto model)
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
            TempData["Active"] = TempDataInfo.Importance;

            return View(_mapper.Map<ImportanceUpdateDto>(_importanceService.GetId(id)));
        }
        [HttpPost]
        public IActionResult UpdateImportance(ImportanceUpdateDto model)
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
