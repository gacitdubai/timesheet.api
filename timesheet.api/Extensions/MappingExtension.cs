using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace timesheet.api.Extensions
{
    public static class MappingExtension
    {
        public static IServiceCollection RegisterAutomapperDependencies(this IServiceCollection service)
        {
            var profilesAssembly = Assembly.Load("timesheet.common");
            var profiles = profilesAssembly.GetTypes()
                .Where(type => type.IsClass
                && !type.IsAbstract
                && type.IsSubclassOf(typeof(Profile))
                && type.Namespace == "timesheet.common.MappingProfiles");
            foreach (var profile in profiles)
            {
                service.AddAutoMapper(profile);
            }

            return service;

        }
    }
}
