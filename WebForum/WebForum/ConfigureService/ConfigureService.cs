﻿using Application.Repositories.Interfaces;
using Application.UseCase.Category.Add;
using Application.UseCase.Category.Delete;
using Application.UseCase.Category.Get;
using Application.UseCase.Category.Update;
using Application.UseCase.Comment.Add;
using Application.UseCase.Comment.Delete;
using Application.UseCase.Comment.Get;
using Application.UseCase.Comment.Update;
using Application.UseCase.Post.Add;
using Application.UseCase.Post.Delete;
using Application.UseCase.Post.Get;
using Application.UseCase.Post.Update;
using Application.UseCase.Topic.Add;
using Application.UseCase.Topic.Delete;
using Application.UseCase.Topic.Get;
using Application.UseCase.Topic.Update;
using Application.UseCase.User.Add;
using Application.UseCase.User.Delete;
using Application.UseCase.User.Get;
using Application.UseCase.User.Update;
using Microsoft.Extensions.DependencyInjection;
using WebForum.Application.Repositories;
using WebForum.Application.UseCase.Category;
using WebForum.Application.UseCase.Comment;
using WebForum.Application.UseCase.Post;
using WebForum.Application.UseCase.Token;
using WebForum.Application.UseCase.Topic;
using WebForum.Application.UseCase.User;
using WebForum.Infrastructure.Repository;

namespace WebForum.WebForumApi.ConfigureService
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAddCategoryUseCase, AddCategoryUseCase>();
            serviceCollection.AddScoped<IRemoveCategoryUseCase, RemoveCategoryUseCase>();
            serviceCollection.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
            serviceCollection.AddScoped<IGetAllCategoryUseCase, GetAllCategoryUseCase>();
            serviceCollection.AddScoped<IGetByIdCategoryUseCase, GetByIdCategoryUseCase>();
            serviceCollection.AddScoped<ICategoryWriteOnlyUseCase, CategoryRepository>();
            serviceCollection.AddScoped<ICategoryReadOnlyUseCase, CategoryRepository>();

            /*TOPIC*/

            serviceCollection.AddScoped<IAddTopicUseCase, AddTopicUseCase>();
            serviceCollection.AddScoped<ITopicRemoveUseCase, TopicRemoveUseCase>();
            serviceCollection.AddScoped<IUpdateTopicUseCase, UpdateTopicUseCase>();
            serviceCollection.AddScoped<IGetAllTopicUseCase, GetAllTopicUseCase>();
            serviceCollection.AddScoped<ITopicGetUseCase, TopicGetUseCase>();
            serviceCollection.AddScoped<ITopicWriteOnlyUseCase, TopicRepository>();
            serviceCollection.AddScoped<ITopicReadOnlyUseCase, TopicRepository>();

            /*POST*/
            serviceCollection.AddScoped<IAddPostUseCase, AddPostUseCase>();
            serviceCollection.AddScoped<IPostRemoveUseCase, PostRemoveUseCase>();
            serviceCollection.AddScoped<IUpdatePostUseCase, UpdatePostUseCase>();
            serviceCollection.AddScoped<IGetAllPostUseCase, GetAllPostUseCase>();
            serviceCollection.AddScoped<IPostGetUseCase, GetByIdPostUseCase>();
            serviceCollection.AddScoped<IPostWriteOnlyUseCase, PostRepository>();
            serviceCollection.AddScoped<IPostReadOnlyUseCase, PostRepository>();

            /*USER*/
            serviceCollection.AddScoped<IAddUserUseCase, AddUserUseCase>();
            serviceCollection.AddScoped<IUserRemoveUseCase, RemoveUserUseCase>();
            serviceCollection.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
            serviceCollection.AddScoped<IGetAllUserUseCase, GetAllUserUseCase>();
            serviceCollection.AddScoped<IGetByIdUserUseCase, GetByIdUserUseCase>();
            serviceCollection.AddScoped<IGetByNameUser, GetByNameUser>();
            serviceCollection.AddScoped<IUserWriteOnlyUseCase, UserRepository>();
            serviceCollection.AddScoped<IUserReadOnlyUseCase, UserRepository>();
            serviceCollection.AddScoped<ITokenRepository, Login>();

            /*Comment*/
            serviceCollection.AddScoped<IAddCommentUseCase, AddCommentUseCase>();
            serviceCollection.AddScoped<IRemoveCommentUseCase, RemoveCommentUseCase>();
            serviceCollection.AddScoped<IUpdateCommentUseCase, UpdateCommentUseCase>();
            serviceCollection.AddScoped<IGetAllCommentUseCase, GetAllCommentUseCase>();
            serviceCollection.AddScoped<IGetByIdCommentUseCase, GetByIdCommentUseCase>();
            serviceCollection.AddScoped<ICommentWriteOnlyUseCase, CommentRepository>();
            serviceCollection.AddScoped<ICommentReadOnlyUseCase, CommentRepository>();
        }
    }
}
