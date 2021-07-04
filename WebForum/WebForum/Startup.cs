using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using System;
using VueCliMiddleware;
using Domain.Entities;
using NSwag;
using Microsoft.Extensions.Options;
using WebForumApi.Swagger;
using Microsoft.AspNetCore.Mvc;
using Autofac;
using Autofac.Configuration;
using System.Linq;
using Infrastructure.Modules;
using WebForumApi.Modules;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;

[assembly: ApiConventionType(typeof(ApiConventions))]
namespace WebForum
{

    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ConfigurationModule(Configuration));
        }
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

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

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                Configuration.GetSection("TokenConfigurations")
            )
            .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);


            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Validates the signing of a received token
                paramsValidation.ValidateIssuerSigningKey = true;

                // Checks if a received token is still valid
                paramsValidation.ValidateLifetime = true;

                // Tolerance time for the expiration of a token (used in case
                // of time synchronization problems between different
                // computers involved in the communication process)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Enables the use of the token as a means of
            // authorizing access to this project's resources
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            //CORS

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:8080");
                });
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "forumvue";
            });

            var builder = new ContainerBuilder();
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<Infrastructure.PostgresData.Module>();
            builder.RegisterModule<InfrastructureDefaultModule>();
            builder.RegisterModule<WebApiModule>();
            builder.Populate(services);

            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(MyAllowSpecificOrigins);

            app.UseOpenApi(config =>
            {
                config.PostProcess = (document, request) =>
                {
                    document.Host = ExtractHost(request);
                    document.BasePath = ExtractPath(request);
                    document.Schemes.Clear();
                };
            });
            app.UseSwaggerUi3(config => config.TransformToExternalPath = (route, request) => ExtractPath(request) + route);
            //Redireciona swagger como pagina inicial
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");

            app.UseRewriter(option);

            app.UseRouting();
            
            app.UseSpaStaticFiles();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                    spa.Options.SourcePath = "forumvue";
                else
                    spa.Options.SourcePath = "dist";
                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }
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

