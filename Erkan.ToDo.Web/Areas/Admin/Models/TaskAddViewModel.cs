using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.Models
{
    public class TaskAddViewModel
    {
        [Required(ErrorMessage ="Ad alanı gereklidir.")]
        public string Name { get; set; }

        public string Explanation { get; set; }
        [Range(0,int.MaxValue, ErrorMessage ="Bir aciliyet durumu seçiniz.")]
        public int ImportanceId { get; set; }

        public SelectList ImportanceList { get; set; }
    }
}
