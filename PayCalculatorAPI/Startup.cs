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

namespace PayCalculatorAPI
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
            services.AddControllers();
            services.AddMvc();
            var pPath = Configuration["PermanentPath"];
            var tPath = Configuration["TempPath"];
            IFileLocator iFileLocator = new FileLocator();
            var findJSONFiles = new FindJSONFiles(pPath, tPath, iFileLocator);
            services.AddSingleton(new EmployeeJSONFormatter<PermanentEmployee>(findJSONFiles.PermanentEmployeeJSONLocation()));
            services.AddSingleton(new EmployeeJSONFormatter<TempEmployee>(findJSONFiles.TempEmployeeJSONLocation()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
