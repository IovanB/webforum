using Autofac;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Infrastructure.Context;
using Infrastructure.Data.AutoMapperProfile;
using Infrastructure.PostgresData.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infrastructure.Modules
{
    public class InfrastructureDefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connection = Environment.GetEnvironmentVariable("DATABASE_CONN");

            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .AsImplementedInterfaces()
                .AsSelf().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(t => (t.Namespace ?? string.Empty).Contains("PostgresData") && typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<InfraProfile>>())
                    cfg.AddProfile(profile);
                cfg.AddExpressionMapping();
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();


            builder.Register(c =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
                optionsBuilder.UseNpgsql(connection); // Assuming PostgreSQL
                return new ApplicationContext(optionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();

            // Optional: Register IDbContextFactory if needed
            builder.RegisterType<ApplicationContext>()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
               .As<IUnitOfWork>()
               .InstancePerLifetimeScope();
        }
    }
}
