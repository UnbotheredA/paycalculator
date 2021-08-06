using Employees;
using Employees.Entites;
using Employees.Entities;
using Employees.Entities.JSON;
using Employees.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PayCalculatorAPI.Controllers;
using PayCalculatorWebApplication.Controllers;

namespace PayCalculatorWebApplication
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
            IConfiguration config = new ConfigurationBuilder().AddJsonFile(@"appsettings.json", false, true).Build();
            var pPath = config["PermanentPath"];
            var tPath = config["TempPath"];
            IFileLocator iFileLocator = new FileLocator();
            var findJSONFiles = new FindJSONFiles(pPath, tPath, iFileLocator);
            services.AddSingleton(new EmployeeJSONFormatter<PermanentEmployee>(findJSONFiles.PermanentEmployeeJSONLocation()));
            services.AddSingleton(new EmployeeJSONFormatter<TempEmployee>(findJSONFiles.TempEmployeeJSONLocation()));
            services.AddControllersWithViews();
            //services.AddRazorPages()
            //    .AddRazorRuntimeCompilation();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
