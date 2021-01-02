using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Erkan.ToDo.Web.Areas.Admin.Models
{
    public class ReportAddViewModel
    {
        [Display(Name ="Detay: ")]
        [Required(ErrorMessage ="Detay alanı boş geçilemez")]
        public string Detail { get; set; }
        [Display(Name = "Tanım: ")]
        [Required(ErrorMessage = "Tanım alanı boş geçilemez")]
        public string Describtion { get; set; }
        public Task Task { get; set; }
        public int TaskId { get; set; }
    }
}
