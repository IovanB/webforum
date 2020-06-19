using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.Repositories;
using WebForum.Application.UseCase.Category;
using WebForum.Application.UseCase.Comment;
using WebForum.Application.UseCase.Post;
using WebForum.Application.UseCase.Token;
using WebForum.Application.UseCase.Topic;
using WebForum.Application.UseCase.User;
using WebForum.Infrastructure.Repository;

namespace ForumTest.Fixed
{
    public class Fixture
    {
        public IContainer Container{ get; set; }
        public Fixture()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AddCategoryUseCase>().As<IAddCategoryUseCase>().InstancePerDependency();
            builder.RegisterType<RemoveCategoryUseCase>().As<IRemoveCategoryUseCase>().InstancePerDependency();
            builder.RegisterType<UpdateCategoryUseCase>().As<IUpdateCategoryUseCase>().InstancePerDependency();
            builder.RegisterType< GetAllCategoryUseCase>().As<IGetAllCategoryUseCase>().InstancePerDependency();
            builder.RegisterType< GetByIdCategoryUseCase>().As<IGetByIdCategoryUseCase>().InstancePerDependency();
            builder.RegisterType<CategoryRepository>().As<ICategoryWriteOnlyUseCase>().InstancePerDependency();
            builder.RegisterType<CategoryRepository>().As<ICategoryReadOnlyUseCase>().InstancePerDependency();

            builder.RegisterType<AddTopicUseCase>().As<IAddTopicUseCase>().InstancePerDependency();
            builder.RegisterType< RemoveTopicUseCase>().As<IRemoveTopicUseCase>().InstancePerDependency();
            builder.RegisterType<UpdateTopicUseCase>().As<IUpdateTopicUseCase>().InstancePerDependency();
            builder.RegisterType<GetAllTopicUseCase>().As<IGetAllTopicUseCase>().InstancePerDependency();
            builder.RegisterType< GetByIdTopicUseCase>().As<IGetByIdTopicUseCase>().InstancePerDependency();
            builder.RegisterType<TopicRepository>().As<ITopicWriteOnlyUseCase>().InstancePerDependency();
            builder.RegisterType<TopicRepository>().As<ITopicReadOnlyUseCase>().InstancePerDependency();

            builder.RegisterType<AddPostUseCase>().As<IAddPostUseCase>().InstancePerDependency();
            builder.RegisterType<RemovePostUseCase>().As<IRemovePostUseCase>().InstancePerDependency();
            builder.RegisterType< UpdatePostUseCase >().As<IUpdatePostUseCase>().InstancePerDependency();
            builder.RegisterType<GetAllPostUseCase>().As<IGetAllPostUseCase>().InstancePerDependency();
            builder.RegisterType<GetByIdPostUseCase>().As<IGetByIdPostUseCase>().InstancePerDependency();
            builder.RegisterType< PostRepository >().As<IPostWriteOnlyUseCase>().InstancePerDependency();
            builder.RegisterType<PostRepository>().As<IPostReadOnlyUseCase>().InstancePerDependency();


            builder.RegisterType<AddUserUseCase>().As<IAddUserUseCase>().InstancePerDependency();
            builder.RegisterType<RemoveUserUseCase>().As<IRemoveUserUseCase>().InstancePerDependency();
            builder.RegisterType<UpdateUserUseCase>().As<IUpdateUserUseCase>().InstancePerDependency();
            builder.RegisterType<GetAllUserUseCase>().As<IGetAllUserUseCase>().InstancePerDependency();
            builder.RegisterType<GetByIdUserUseCase>().As<IGetByIdUserUseCase>().InstancePerDependency();
            builder.RegisterType<GetByNameUser>().As<IGetByNameUser>().InstancePerDependency();
            builder.RegisterType<UserRepository>().As<IUserWriteOnlyUseCase>().InstancePerDependency();
            builder.RegisterType<UserRepository>().As<IUserReadOnlyUseCase>().InstancePerDependency();
            builder.RegisterType<Login>().As<ITokenRepository>().InstancePerDependency();


            builder.RegisterType<AddCommentUseCase>().As<IAddCommentUseCase>().InstancePerDependency();
            builder.RegisterType<RemoveCommentUseCase>().As<IRemoveCommentUseCase>().InstancePerDependency();
            builder.RegisterType<UpdateCommentUseCase>().As<IUpdateCommentUseCase>().InstancePerDependency();
            builder.RegisterType<GetAllCommentUseCase>().As<IGetAllCommentUseCase>().InstancePerDependency();
            builder.RegisterType<GetByIdCommentUseCase>().As<IGetByIdCommentUseCase>().InstancePerDependency();
            builder.RegisterType<CommentRepository>().As<ICommentWriteOnlyUseCase>().InstancePerDependency();
            builder.RegisterType<CommentRepository>().As<ICommentReadOnlyUseCase>().InstancePerDependency();

            Container = builder.Build();
        }  
    }
}
