using System;
using Archive.CDManagement.Frontend.Configuration;
using Archive.CDManagement.Frontend.Repositories;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Archive.CDManagement.Frontend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var settings = new MySettings();
            Configuration.Bind("MySettings", settings);
            services.AddRazorPages();

            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddHttpClient<ICDRepository, CDRepository>();
            services.AddHttpClient<IRentalRepository, RentalRepository>();
            services.AddHttpClient<IStaffRepository, StaffRepository>();
            services.AddHttpClient<IReportRepository, ReportRepository>();
            services.AddSingleton<MySettings>(settings);

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(50);
                options.Cookie.Name = ".CdManagement.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}