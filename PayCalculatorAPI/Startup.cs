using Employees.Entites;
using Employees.Entities;
using Employees.Entities.JSON;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

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
            //I added this
            services.AddMvc();
            var pPath = Configuration["PermanentPath"];
            var tPath = Configuration["TempPath"];

            var findJSONFiles = new FindJSONFiles(pPath, tPath);
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
           //I added this
            app.UseDeveloperExceptionPage();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
