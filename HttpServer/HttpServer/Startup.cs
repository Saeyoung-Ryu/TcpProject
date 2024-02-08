using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HttpServer.Data;

namespace HttpServer
{
    public class Startup
    {
        // public void ConfigureServices(IServiceCollection services)
        // {
        //     
        // }
        //
        // public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        // {
        //     Console.WriteLine("Startup");
        //     app.UseMiddleware<Route>();
        // }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Ensure that the UseMiddleware<Route>() call is before the UseEndpoints middleware
            app.UseMiddleware<Route>();

            app.UseEndpoints(endpoints =>
            {
                // Map Blazor hub
                endpoints.MapBlazorHub();

                // Map the fallback route to the Blazor _Host page
                endpoints.MapFallbackToPage("/_Host");
            });
        }




    }
}