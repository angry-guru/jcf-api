using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using jcf_api.Clients;
using jcf_api.Mapping;
using jcf_api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace jcf_api
{
    public class Startup
    {
        private readonly Uri emissionClientUrl;

        public Startup(IConfiguration configuration)
        {
            emissionClientUrl = configuration.GetSection("ClientUrls").GetValue<Uri>("EmmisionClient");

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            string version = typeof(Startup).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

            services.AddSwaggerDocument(settings =>
            {
                settings.Title = "JCF Api";
                settings.Description = "Jewelry Carbon Footprint calculator Api";
                settings.Version = version;
            });

            services.AddTransient<OptionsService>();
            services.AddTransient<EmissionService>();
            services.AddTransient<EmissionClient>(_ => new EmissionClient(emissionClientUrl));

            var config = new MapperConfiguration(_ => { _.AddProfile<MappingProfile>(); });

            var mapper = config.CreateMapper();

            services.AddTransient(_ => mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger(settings =>
            {
                settings.Path = "/swagger/v1/swagger.json";
            })
            .UseSwaggerUi3();

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
                builder.AllowCredentials();
            });

            app.UseMvc();
        }
    }
}
