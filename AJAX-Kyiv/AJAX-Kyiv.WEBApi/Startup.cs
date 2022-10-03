using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Footballers.Application.Common.Mapping;
using System.Reflection;
using Footballers.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Footballer.Application;
using Footballer.Persistence;
using AJAX_Kyiv.WEBApi.Middleware;
using System;
using System.IO;
using MediatR;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Footballers.Application.Footballers.Queries.GetFootballerList;
using Footballers.Application.Footballers.Queries.GetFootballerDetails;

namespace AJAX_Kyiv.WEBApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FootballersDbContext>(options =>
                options.UseInMemoryDatabase(Configuration.GetConnectionString("MyDb")));

            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IFootballersDbContext).Assembly));
                config.AddProfile(new AssemblyMappingProfile(typeof(GetFootballerListQueryHandler).Assembly));
                //config.AddProfile(new AssemblyMappingProfile(typeof(GetFootballersDeatailsQueryHandler).Assembly));
            });

            var assemblyQueries = AppDomain.CurrentDomain.Load("Queries");
            services.AddMediatR(assemblyQueries);

            var assemblyCommands = AppDomain.CurrentDomain.Load("Commands");
            services.AddMediatR(assemblyCommands);

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            services.AddSwaggerGen(config =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.RoutePrefix = string.Empty;
                config.SwaggerEndpoint("swagger/v1/swagger.json", "AJAX-Kyiv API");
            });
            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
