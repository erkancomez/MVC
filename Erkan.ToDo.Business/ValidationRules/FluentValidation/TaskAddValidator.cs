using Erkan.ToDo.DTO.DTOs.TaskDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.ValidationRules.FluentValidation
{
    public class TaskAddValidator : AbstractValidator<TaskAddDto>
    {
        public TaskAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad alanı boş geçilemez.");
            RuleFor(I => I.ImportanceId).ExclusiveBetween(1,int.MaxValue).WithMessage("Lütfen bir aciliyet durumu seçiniz.");
        }
    }
}
