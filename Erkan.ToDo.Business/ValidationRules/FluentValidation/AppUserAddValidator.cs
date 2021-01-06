using Erkan.ToDo.DTO.DTOs.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(I => I.Password).NotNull().WithMessage("Şifre boş geçilemez.");
            RuleFor(I => I.ConfirmPassword).NotNull().WithMessage("Şifre onay alanı boş geçilemez.");
            RuleFor(I => I.ConfirmPassword).Equal(I => I.Password).WithMessage("Şifreler eşleşmiyor.");
            RuleFor(I => I.Email).NotNull().WithMessage("Email boş geçilemez.").EmailAddress().WithMessage("Geçersiz email formatı.");
            RuleFor(I => I.Name).NotNull().WithMessage("Ad alanı boş geçilemez.");
            RuleFor(I => I.Surname).NotNull().WithMessage("Soyad alanı boş geçilemez.");
        }
    }
}
