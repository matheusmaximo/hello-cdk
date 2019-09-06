using HelloCdkApiLambda.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace HelloCdkApiLambda
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCustomMvcCore();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseForwardedHeaders();
                app.UseHttpsRedirection();
            }

            app.UseHttpsRedirection();
            app.UseApiVersioning();
            app.UseMvc();
        }
    }
}
