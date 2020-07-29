using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazorPageOverride.Infra;

namespace RazorPageOverride
{
    public class Startup
    {
        private IWebHostEnvironment Env { get; }
        
        public Startup(IWebHostEnvironment env)
        {
            Env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.PageViewLocationFormats.Add("/Pages/Theme/{0}.cshtml");
                options.PageViewLocationFormats.Add("/Pages/Overrides/{0}.cshtml");
                
                // Add more view locations which the view engine will use to resolve views
                // This allows for easy overriding of the base theme pages by adding an overriding view in Pages/Overrides
                options.ViewLocationExpanders.Add(new ThemeViewLocationExpander());
            });

            var mvcBuilder = services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    // Configure overriding pages to take precedence over standard theme pages
                    options.Conventions.Add(new ThemeTemplatePageRouteModelConvention());
                })
                .AddMvcOptions(x => x.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            if (Env.IsDevelopment())
            {
                mvcBuilder.AddRazorRuntimeCompilation();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}