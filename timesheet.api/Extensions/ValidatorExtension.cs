using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using timesheet.common.Requests;
using timesheet.common.Validators;
using timesheet.comomon.Requests;

namespace timesheet.api.Extensions
{
    public static class ValidatorExtension
    {
        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<AddNewTaskRequest>, AddNewTaskValidator>();
            services.AddScoped<IValidator<CreateEmployeeRequest>, CreateEmployeeRequestValidator>();
            return services;
        }
    }
}
