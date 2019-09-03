using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace HelloCdkApi.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomMvcCore(this IServiceCollection service)
        {
            service
                .AddRouting(options => options.LowercaseUrls = true);

            service
                .AddMvcCore(options =>
                 {
                     options.Filters.Add(new ConsumesAttribute("application/json"));
                     options.Filters.Add(new ProducesAttribute("application/json"));
                 })
                .AddApiExplorer()
                .AddFormatterMappings()
                .AddDataAnnotations()
                .AddJsonFormatters(setupAction =>
                {
                    setupAction.NullValueHandling = NullValueHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddControllersAsServices();

            return service;
        }
    }
}
