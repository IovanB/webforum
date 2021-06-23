using Autofac;
using WebForum;
using WebForumApi.UseCase.Category;
using WebForumApi.UseCase.Comment;
using WebForumApi.UseCase.Post;
using WebForumApi.UseCase.Topic;
using WebForumApi.UseCase.User;

namespace WebForumApi.Modules
{
    public class WebApiModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<CategoryPresenter>().As<Application.Boundaries.Category.IOutputPort>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<TopicPresenter>().As<Application.Boundaries.Topic.IOutputPort>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<PostPresenter>().As<Application.Boundaries.Post.IOutputPort>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CommentPresenter>().As<Application.Boundaries.Comment.IOutputPort>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UserPresenter>().As<Application.Boundaries.User.IOutputPort>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
