using Autofac;
using Infrastructure.Modules;
using WebForumApi.Modules;

namespace WebForumApi.DependencyInjection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureDefaultModule>();
            builder.RegisterModule<WebApiModule>();

            return builder;
        }
    }
}
