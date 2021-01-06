using Erkan.ToDo.DTO.DTOs.ReportDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.ValidationRules.FluentValidation
{
    class ReportAddValidator:AbstractValidator<ReportAddDto>
    {
        public ReportAddValidator()
        {
            RuleFor(I => I.Describtion).NotNull().WithMessage("Tanım alanı boş geçilemez.");
            RuleFor(I => I.Detail).NotNull().WithMessage("Detay alanı boş geçilemez.");
        }
    }
}
