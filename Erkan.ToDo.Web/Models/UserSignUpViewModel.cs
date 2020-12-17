using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Models
{
    public class UserSignUpViewModel
    {
        [Required]
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
