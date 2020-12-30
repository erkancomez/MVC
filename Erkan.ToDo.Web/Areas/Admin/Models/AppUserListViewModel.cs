using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.Models
{
    public class AppUserListViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad alanı boş geçilemez")]
        [Display(Name="Ad: ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        [Display(Name = "Soyad: ")]
        public string SurName { get; set; }
        [Display(Name = "Email: ")]
        public string Email { get; set; }
        [Display(Name = "Resim: ")]
        public string Picture { get; set; }
    }
}
