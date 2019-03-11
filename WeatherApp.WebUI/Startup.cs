using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WeatherApp.Application.Infrastructure;
using WeatherApp.Application.Interfaces;
using WeatherApp.Application.Users.Commands.SignUpUser;
using WeatherApp.Application.Weather.Commands.AddCity;
using WeatherApp.Infrastructure.Helpers;
using WeatherApp.Infrastructure.Identity;
using WeatherApp.Infrastructure.Services;
using WeatherApp.Persistence.Context;
using WeatherApp.WebUI.Bootstrapping;
using WeatherApp.WebUI.Filters;

namespace WeatherApp.WebUI
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
            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(AddCityCommandHandler).GetTypeInfo().Assembly);
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddDbContext<ApplicationDbContext>(options=>
            options.UseSqlServer(Configuration.GetConnectionString("WeatherDatabase")));
            services.AddIdentity();
            services.AddMvc(options => options.ModelValidatorProviders.Clear())
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginUserCommandValidator>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<ApiSettings>(options => Configuration.GetSection("WeatherDataSource").Bind(options));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Home/Error");
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
