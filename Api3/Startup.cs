using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Persistence;
using Service;
using System.Reflection;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api3
{
    class Startup
    {
        public IHostingEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = "Server=localhost;Port=5432;Database=test;User Id=postgres;Password=cooliris;";
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
           services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            services.AddDbContext<StudentDbContext>(options => options.UseNpgsql(connection, sql => sql.MigrationsAssembly(migrationsAssembly)));

            services.AddTransient<IStudentService, StudentService>();

            services.AddControllers();
               


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
               //pp.UseHsts();
            }
          app.UseRouting();
            app.UseCors("default");

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });


        }

    }


}
