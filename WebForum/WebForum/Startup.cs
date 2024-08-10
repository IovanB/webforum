using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using System;
using Domain.Entities;
using NSwag;
using Microsoft.Extensions.Options;
using WebForumApi.Swagger;
using Microsoft.AspNetCore.Mvc;
using Autofac;
using Autofac.Configuration;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Autofac.Extensions.DependencyInjection;
using WebForumApi.DependencyInjection;
using Microsoft.Extensions.Localization;
using Infrastructure.PostgresData.Repository.UnitOfWork;

[assembly: ApiConventionType(typeof(ApiConventions))]
namespace WebForum
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ConfigurationModule(Configuration));
            builder.AddAutofacRegistration();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddAutofac();
            services.AddControllers();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerDocument(document =>
            {
                document.Title = "Forum API";
                document.Version = "v1";
                document.PostProcess = s =>
                {
                    s.Paths.ToList().ForEach(p =>
                    {
                        p.Value.Parameters.Add(
                        new OpenApiParameter()
                        {
                            Kind = OpenApiParameterKind.Header,
                            Type = NJsonSchema.JsonObjectType.String,
                            IsRequired = false,
                            Name = "Accept-Language",
                            Description = "pt-BR or en-US",
                            Default = "pt-BR"
                        });
                    });
                };
            });
           
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var serviceProvider = app.ApplicationServices;
            var resouces = serviceProvider.GetService<IStringLocalizer<ReturnMessages>>();

            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();


            app.UseOpenApi(config =>
            {
                config.PostProcess = (document, request) =>
                {
                    document.Host = ExtractHost(request);
                    document.BasePath = ExtractPath(request);
                    document.Schemes.Clear();
                };
            });
            app.UseSwaggerUi(config => config.TransformToExternalPath = (route, request) => ExtractPath(request) + route);
            //Redireciona swagger como pagina inicial
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");

            app.UseRewriter(option);

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private string ExtractHost(HttpRequest request) =>
          request.Headers.ContainsKey("X-Forwarded-Host") ?
              new Uri($"{ExtractProto(request)}://{request.Headers["X-Forwarded-Host"].First()}").Host :
                  request.Host.Value;

        private string ExtractProto(HttpRequest request) =>
            request.Headers["X-Forwarded-Proto"].FirstOrDefault() ?? request.Protocol;

        private string ExtractPath(HttpRequest request) =>
            request.Headers.ContainsKey("X-Forwarded-Prefix") ?
                request.Headers["X-Forwarded-Prefix"].FirstOrDefault() :
                string.Empty;
    }
}

