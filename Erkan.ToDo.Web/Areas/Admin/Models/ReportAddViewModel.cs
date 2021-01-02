using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.Models
{
    public class ReportAddViewModel
    {
        [Display(Name ="Detay: ")]
        [Required(ErrorMessage ="Detay alanı boş geçilemez")]
        public string Detail { get; set; }
        [Display(Name = "Tanım: ")]
        [Required(ErrorMessage = "Tanım alanı boş geçilemez")]
        public string Definition { get; set; }
        public int TaskId { get; set; }
    }
}
