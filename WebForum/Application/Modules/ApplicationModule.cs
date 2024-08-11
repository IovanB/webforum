using Application.UseCases;
using Autofac;
using Domain.Entities;
using System;

namespace Application.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).Where(w => (w.Namespace ?? string.Empty).Contains("UseCases")).AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<CategoryUseCase>()
               .As<ICommonUseCase<Category>>()
               .InstancePerLifetimeScope();

            builder.RegisterType<PostUseCase>()
               .As<ICommonUseCase<Post>>()
               .InstancePerLifetimeScope();

            builder.RegisterType<TopicUseCase>()
               .As<ICommonUseCase<Topic>>()
               .InstancePerLifetimeScope();

            builder.RegisterType<CommentUseCase>()
               .As<ICommonUseCase<Comment>>()
               .InstancePerLifetimeScope();


        }
    }
}
