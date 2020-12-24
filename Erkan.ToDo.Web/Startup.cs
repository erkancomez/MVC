using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Business.Concrete;
using Erkan.ToDo.DataAccess.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Contexts;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Repositories;
using Erkan.ToDo.Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Erkan.ToDo.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskManager>();
            services.AddScoped<IImportanceService, ImportanceManager>();
            services.AddScoped<IReportService, ReportManager>();

            services.AddScoped<ITaskDal, EfTaskRepository>();
            services.AddScoped<IReportDal, EfReportRepository>();
            services.AddScoped<IImportanceDal, EfImportanceRepository>();

            services.AddDbContext<ToDoContext>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ToDoContext>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
