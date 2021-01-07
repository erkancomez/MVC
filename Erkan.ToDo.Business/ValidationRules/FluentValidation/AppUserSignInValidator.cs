using Erkan.ToDo.DTO.DTOs.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator: AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(I => I.Password).NotNull().WithMessage("Şifre boş geçilemez.");
        }
    }
}
