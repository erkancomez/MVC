using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Business.Concrete;
using Erkan.ToDo.DataAccess.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.DiContainer
{
    public static class CustomExtension
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskManager>();
            services.AddScoped<IImportanceService, ImportanceManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<ITaskDal, EfTaskRepository>();
            services.AddScoped<IReportDal, EfReportRepository>();
            services.AddScoped<IImportanceDal, EfImportanceRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<INotificationDal, EfNotificationRepository>();
        }
    }
}
