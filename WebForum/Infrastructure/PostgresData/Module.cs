using Autofac;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.PostgresData
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connection = Environment.GetEnvironmentVariable("DATABASE_CONN");

            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace.Contains("PostgresData"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(t => t.Namespace.Contains("PostgresData") && typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            //builder.Register(c => new MapperConfiguration(cfg =>
            //{
            //    foreach (var profile in c.Resolve<IEnumerable<Profile>>())
            //        cfg.AddProfile(profile);

            //    cfg.AddExpressionMapping();
            //})).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationContext>().InstancePerLifetimeScope();

            if (!string.IsNullOrEmpty(connection))
            {
                using (var context = new ApplicationContext())
                {
                    context.Database.Migrate();
                    //ContextInitializer.Seed(context);
                }
            }
        }
    }
}
