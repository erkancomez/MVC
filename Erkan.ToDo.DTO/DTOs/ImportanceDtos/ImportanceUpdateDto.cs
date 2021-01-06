using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.DTO.DTOs.ImportanceDtos
{
    public class ImportanceUpdateDto
    {
        public int Id { get; set; }
        //[Display(Name = "Tanım: ")]
        //[Required(ErrorMessage = "Tanım alanı gereklidir.")]
        public string Definition { get; set; }
    }
}
