using Infrastructure.Data.Entity.Entities;
using Microsoft.Extensions.DependencyInjection;
using WebForum.Application.Repositories;
using WebForum.Application.UseCase.Category;

namespace WebForum.WebForumApi.ConfigureService
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        //{
        //    serviceCollection.AddScoped<IWriteOnlyUseCase<Category>, AddCategoryUseCase>();
        //    serviceCollection.AddScoped<IRemoveCategoryUseCase, RemoveCategoryUseCase>();
        //    serviceCollection.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
        //    serviceCollection.AddScoped<IGetAllCategoryUseCase, GetAllCategoryUseCase>();
        //    serviceCollection.AddScoped<IGetByIdCategoryUseCase, GetByIdCategoryUseCase>();
        //    serviceCollection.AddScoped<ICategoryWriteOnlyUseCase, CategoryRepository>();
        //    serviceCollection.AddScoped<ICategoryReadOnlyUseCase, CategoryRepository>();

        //    /*TOPIC*/

        //    serviceCollection.AddScoped<IAddTopicUseCase, AddTopicUseCase>();
        //    serviceCollection.AddScoped<IRemoveTopicUseCase, RemoveTopicUseCase>();
        //    serviceCollection.AddScoped<IUpdateTopicUseCase, UpdateTopicUseCase>();
        //    serviceCollection.AddScoped<IGetAllTopicUseCase, GetAllTopicUseCase>();
        //    serviceCollection.AddScoped<IGetByIdTopicUseCase, GetByIdTopicUseCase>();
        //    serviceCollection.AddScoped<ITopicWriteOnlyUseCase, TopicRepository>();
        //    serviceCollection.AddScoped<ITopicReadOnlyUseCase, TopicRepository>();

        //    /*POST*/
        //    serviceCollection.AddScoped<IAddPostUseCase, AddPostUseCase>();
        //    serviceCollection.AddScoped<IRemovePostUseCase, RemovePostUseCase>();
        //    serviceCollection.AddScoped<IUpdatePostUseCase, UpdatePostUseCase>();
        //    serviceCollection.AddScoped<IGetAllPostUseCase, GetAllPostUseCase>();
        //    serviceCollection.AddScoped<IGetByIdPostUseCase, GetByIdPostUseCase>();
        //    serviceCollection.AddScoped<IPostWriteOnlyUseCase, PostRepository>();
        //    serviceCollection.AddScoped<IPostReadOnlyUseCase, PostRepository>();

        //    /*USER*/
        //    serviceCollection.AddScoped<IAddUserUseCase, AddUserUseCase>();
        //    serviceCollection.AddScoped<IRemoveUserUseCase, RemoveUserUseCase>();
        //    serviceCollection.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
        //    serviceCollection.AddScoped<IGetAllUserUseCase, GetAllUserUseCase>();
        //    serviceCollection.AddScoped<IGetByIdUserUseCase, GetByIdUserUseCase>();
        //    serviceCollection.AddScoped<IGetByNameUser, GetByNameUser>();
        //    serviceCollection.AddScoped<IUserWriteOnlyUseCase, UserRepository>();
        //    serviceCollection.AddScoped<IUserReadOnlyUseCase, UserRepository>();
        //    serviceCollection.AddScoped<ITokenRepository, Login>();

        //    /*Comment*/
        //    serviceCollection.AddScoped<IAddCommentUseCase, AddCommentUseCase>();
        //    serviceCollection.AddScoped<IRemoveCommentUseCase, RemoveCommentUseCase>();
        //    serviceCollection.AddScoped<IUpdateCommentUseCase, UpdateCommentUseCase>();
        //    serviceCollection.AddScoped<IGetAllCommentUseCase, GetAllCommentUseCase>();
        //    serviceCollection.AddScoped<IGetByIdCommentUseCase, GetByIdCommentUseCase>();
        //    serviceCollection.AddScoped<ICommentWriteOnlyUseCase, CommentRepository>();
        //    serviceCollection.AddScoped<ICommentReadOnlyUseCase, CommentRepository>();
        }
    }
}
