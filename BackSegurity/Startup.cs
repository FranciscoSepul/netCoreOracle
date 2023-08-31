using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BackSecurity.Services.IServices;
using BackSecurity.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using BackSecurity.Services.Common.ICommon;
using BackSecurity.Services.Common;
using BackSecurity.Services;

namespace BackSecurity
{
    public partial class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly ILogger _logger;
        public IContainer ApplicationContainer { get; private set; }


        public Startup(IConfiguration configuration,
            ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddRazorPages();

            services.Configure<IISServerOptions>(options => { });


            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            services.AddMvcCore().AddApiExplorer();

            ConfigurarServicios(services);
            services.AddSession();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            AddSwagger(services);
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";
                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Security {groupName}",
                    Version = groupName,
                    Description = "Security API",
                    Contact = new OpenApiContact
                    {
                        Name = "Security Company",
                        Email = string.Empty,
                        Url = new Uri("https://Security.com/"),
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                DeveloperExceptionPageOptions developerExceptionPageOptions = new()
                {
                    SourceCodeLineCount = 5
                };
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Security API V1");
            });

            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();

            });
        }

        public void ConfigurarServicios(IServiceCollection services)
        {
            services.AddTransient<IHttpService, HttpService>();
            services.AddTransient<IUserService ,UserService>();
        }

    }
}
