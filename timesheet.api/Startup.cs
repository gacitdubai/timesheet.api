using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using timesheet.api.Extensions;
using timesheet.api.Middlewares;
using timesheet.business;
using timesheet.common.Configurations;
using timesheet.data;

namespace timesheet.api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                                  builder => builder.WithOrigins("http://localhost:4200")
                                                    .AllowAnyMethod()
                                                    .AllowAnyHeader()
                                                    .AllowCredentials());
            });

            services.RegisterDependencies();
            services.RegisterValidators();
            services.RegisterAutomapperDependencies();
            var timeSheetConfig = TimeSheetConfig.LoadTimeSheetConfig();
            services.AddDbContext<TimesheetDb>(options => 
                    options.UseSqlServer(timeSheetConfig.ConnectionString), ServiceLifetime.Scoped);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Timesheet API",
                    Version = "v1",
                    Description = "API documentation for the Timesheet application"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                // Enable Swagger UI middleware to serve Swagger UI
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Timesheet API V1");
                    c.RoutePrefix = string.Empty; // Serve Swagger UI at the root (optional)
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseMiddleware<GlobalExceptionMiddleware>();
            // Map controllers to endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();  // This is critical to ensure controllers are available to Swagger
            });

        }
    }
}
