using Erkan.ToDo.Web.Constraints;
using Erkan.ToDo.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            //app.UseStatusCodePagesWithReExecute("/Home/PageError", "?code={0}");
            //app.UseStatusCodePages();
            app.UseSession();
            app.UseStaticFiles();
            app.UseCustomStaticFile();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                    //defaults: new { controller = "Home", action = "Index" },
                    //constraints: new { language = new Programming() }
                    );
                endpoints.MapControllerRoute(
                    name: "programmingRoute",
                    pattern: "programming/{language}",
                    defaults: new { controller = "Home", action = "Index" },
                    constraints:new {language=new Programming()}
                    );
                endpoints.MapControllerRoute(
                    name: "person",
                    pattern: "persons",
                    defaults: new { controller = "Home", action = "Index" }
                    );
                endpoints.MapControllerRoute(

                    name: "default",
                    pattern: "{controller=Home}/{action=Index}"
                    );

            });
        }
    }
}
