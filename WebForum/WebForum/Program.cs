using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Autofac.Configuration;
using Microsoft.AspNetCore.Builder;
using WebForumApi.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebForumApi;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONN") ?? "InMemoryDatabase";
        builder.Services.AddDbContext<ApplicationContext>(options =>
        {
            if (connectionString.StartsWith("Host="))
            {
                options.UseNpgsql(connectionString, npgsqlOptionsAction: npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                    npgsqlOptions.MigrationsHistoryTable("_MigrationHistory", "webforum");
                });
            }
            else
            {
                options.UseInMemoryDatabase("InMemoryProvider");
            }
        });

        // Add services to the container.
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        // Register Autofac modules and services
        builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            containerBuilder.RegisterModule(new ConfigurationModule(builder.Configuration));
            containerBuilder.AddAutofacRegistration();
        });

        // Add services to the DI container.
        builder.Services.AddControllers();

        // Add Swagger services
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "WebForumAPI",
                Description = "Here is an example of a simple webforum api",
            });

        });

        // Build the WebApplication
        var app = builder.Build();

        // Autofac container
        var autofacContainer = app.Services.GetAutofacRoot();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            // Enable Swagger middleware
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WEB FORUM API V1");
                c.RoutePrefix = string.Empty; // Serve Swagger UI at the root of the app
            });

            // Redirect to Swagger UI when the root URL is accessed
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/swagger");
                    return;
                }
                await next();
            });
        }

        // Enable Swagger middleware
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "WEB FORUM API V1");
            c.RoutePrefix = string.Empty; // Serve Swagger UI at the root of the app
        });

        // Redirect to Swagger UI when the root URL is accessed
        app.Use(async (context, next) =>
        {
            if (context.Request.Path == "/")
            {
                context.Response.Redirect("/swagger");
                return;
            }
            await next();
        });

        var serviceProvider = app.Services;

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });



        // Run the application
        app.Run();
    }
}