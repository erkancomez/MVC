using Erkan.ToDo.Business.ValidationRules.FluentValidation;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Contexts;
using Erkan.ToDo.DTO.DTOs.AppUserDtos;
using Erkan.ToDo.DTO.DTOs.ImportanceDtos;
using Erkan.ToDo.DTO.DTOs.ReportDtos;
using Erkan.ToDo.DTO.DTOs.TaskDtos;
using Erkan.ToDo.Entities.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Erkan.ToDo.Web.CustomCollectionsExtension
{
    public static class CollectionExtension
    {
       public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ToDoContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "IsTakipCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.LoginPath = "/Home/Index";
            });
        }

        public static void AddCustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<ImportanceAddDto>, ImportanceAddValidator>();
            services.AddTransient<IValidator<ImportanceUpdateDto>, ImportanceUpdateValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
            services.AddTransient<IValidator<TaskAddDto>, TaskAddValidator>();
            services.AddTransient<IValidator<TaskUpdateDto>, TaskUpdateValidator>();
            services.AddTransient<IValidator<ReportAddDto>, ReportAddValidator>();
            services.AddTransient<IValidator<ReportUpdateDto>, ReportUpdateValidator>();
        }
    }
}
