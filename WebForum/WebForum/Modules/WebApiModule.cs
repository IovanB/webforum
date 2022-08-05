using Autofac;
using System.Linq;
using WebForum;
using WebForumApi.UseCase.Category;
using WebForumApi.UseCase.Comment;
using WebForumApi.UseCase.Post;
using WebForumApi.UseCase.Topic;
using WebForumApi.UseCase.User;

namespace WebForumApi.Modules
{
    public class WebApiModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(typeof(Startup).Assembly).Where(w => w.Namespace.Contains("UseCases")).AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly).Where(type => type.Namespace.Contains("Infrastructure")).AsImplementedInterfaces().InstancePerLifetimeScope();



            builder.RegisterType<CategoryPresenter>().As<Application.Boundaries.Category.IOutputPort>().AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .AsSelf();
            builder.RegisterType<TopicPresenter>().As<Application.Boundaries.Topic.IOutputPort>().AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .AsSelf();
            builder.RegisterType<PostPresenter>().As<Application.Boundaries.Post.IOutputPort>().AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .AsSelf();
            builder.RegisterType<CommentPresenter>().As<Application.Boundaries.Comment.IOutputPort>().AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .AsSelf();
            builder.RegisterType<UserPresenter>().As<Application.Boundaries.User.IOutputPort>().AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .AsSelf();
        }
    }
}
