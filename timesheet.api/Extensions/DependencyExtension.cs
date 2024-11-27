using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using timesheet.business;
using timesheet.common.Interfaces;
using timesheet.data;

namespace timesheet.api.Extensions
{
    public static class DependencyExtension
    {

        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            // Services
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IEmployeeService, EmployeeService>();


            //Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ITaskRespository, TaskRepository>();
            return services;
        }
    }
}
