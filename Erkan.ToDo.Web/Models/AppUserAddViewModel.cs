using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Models
{
    public class AppUserAddViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez")]
        [Display(Name="Kullanıcı Adı: ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre: ")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Şifreler eşleşmiyor")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifreyi tekrar giriniz: ")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email  boş geçilemez")]
        [EmailAddress(ErrorMessage ="Geçersiz e-posta")]
        [Display(Name = "E-posta: ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ad boş geçilemez")]
        [Display(Name = "Ad: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad boş geçilemez")]
        [Display(Name = "Soyad: ")]
        public string Surname { get; set; }
    }
}
