using Autofac;
using AutoMapper;
using System;

namespace Infrastructure.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).Where(w => (w.Namespace ?? string.Empty).Contains("UseCases")).AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
        }
    }
}
