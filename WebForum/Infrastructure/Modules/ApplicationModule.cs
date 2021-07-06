using Autofac;
using AutoMapper;
using System;

namespace Infrastructure.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Application.ApplicationException).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(Application.ApplicationException).Assembly)
                .Where(t => (t.Namespace ?? string.Empty).Contains("PostgresData") && typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).Where(w => (w.Namespace ?? string.Empty).Contains("UseCases")).AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
        }
    }
}
