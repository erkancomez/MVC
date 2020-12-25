using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.Models
{
    public class ImportanceUpdateViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Tanım: ")]
        [Required(ErrorMessage ="Tanım alanı gereklidir.")]
        public string Definition { get; set; }
    }
}
