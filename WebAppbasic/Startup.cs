using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAppbasic
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                        name: "FeverCheck",
                        pattern: "FeverCheck",
                        defaults: new { controller = "Temp", action = "FeverCheck" });
                endpoints.MapControllerRoute(
                     name: "Game",
                     pattern: "GuessingGame",
                     defaults: new { controller = "Game", action = "RandomNumber" });


                endpoints.MapControllerRoute(
                    name: "about",
                    pattern: "App/About/{id?}",
                    defaults: new { controller = "App", action = "About" });

                endpoints.MapControllerRoute(
                    name: "contact",
                    pattern: "App/Contact/{id?}",
                    defaults: new { controller = "App", action = "Contact" });

                endpoints.MapControllerRoute(
                    name: "projects",
                    pattern: "App/Projects/{id?}",
                    defaults: new { controller = "App", action = "Projects" });
                
                });
            
        }
    }
}
