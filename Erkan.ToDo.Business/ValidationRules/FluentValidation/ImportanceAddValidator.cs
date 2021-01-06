using Erkan.ToDo.DTO.DTOs.ImportanceDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.ValidationRules.FluentValidation
{
    public class ImportanceAddValidator : AbstractValidator<ImportanceAddDto>
    {
        public ImportanceAddValidator()
        {
            RuleFor(I => I.Definition).NotNull().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
