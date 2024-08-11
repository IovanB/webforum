using Autofac;
using System.Linq;
using WebForum;

namespace WebForumApi.Modules
{
    public class WebApiModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Program).Assembly).Where(w => w.Namespace.Contains("UseCases")).AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(Program).Assembly).Where(type => type.Namespace.Contains("Infrastructure")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
