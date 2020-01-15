using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data.Models;
using Repo;
using Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ExpressBasicQuality
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
            services.AddRazorPages();
            services.AddSession();

            services.AddMvc().AddRazorPagesOptions(options =>
            {                
                options.Conventions.AddPageRoute("/Login", "");
            });
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IFirmaBolgeTanimService, FirmaBolgeTanimService>();
            //services.AddScoped<ITbSystemNumaraService, TbSystemNumaraService>();
            //services.AddScoped<IFirmaSektorTanimService, FirmaSektorTanimService>();
            //services.AddScoped<IFirmaService, FirmaService>();
            //services.AddScoped<IismerkezService, ismerkezService>();
            services.AddDbContext<DataContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<DataContext>(options => options.UseSqlServer("Server=DESKTOP-F8V4AUN;Database=Test2024;User Id=sa;Password=Sql123654*;Trusted_Connection=True;"));
            services.AddRouting();
            services.AddMemoryCache();
            services.AddSession();
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapRazorPages();
            });
        }
    }
}
