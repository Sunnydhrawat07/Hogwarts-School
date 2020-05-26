using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseAPI.Models;
using CourseAPI.Services;
using UserAPI.Models;
using UserAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace UserAPI
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
            services.AddDbContext<UserContext>
                (opt => opt.UseSqlServer(Configuration["Data:CommandAPIConnection:ConnectionString"]));
                services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Hogwarts School API",
                        Version = "v1"
                    });
                setupAction.ResolveConflictingActions(apiDescriptions =>
                apiDescriptions.First());
            });
        services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<CourseContext>
                (opt => opt.UseSqlServer(Configuration["Data:CommandAPIConnection:ConnectionString"]));
            services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddTransient<IStudentService,StudentService>();
            services.AddTransient<ICourseService,CourseService>();
            services.AddTransient<ITeacherService,TeacherService>();
            services.AddTransient<IStaffService,StaffService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix ="HogwartsSchoolAPI";
                c.SwaggerEndpoint("../swagger/v1/swagger.json","Hogwarts School API");
                c.InjectStylesheet("../css/swagger.min.css");
            }
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
