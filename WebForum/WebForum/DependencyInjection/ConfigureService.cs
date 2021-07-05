using Application.Repositories.Interfaces;
using Application.UseCase.Category.Save;
using Infrastructure.PostgresData.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace WebForumApi.DependencyInjection
{
    public class ConfigureService
    {

        public static void ConfigureDependenciesService(IServiceCollection service)
        {
            service.AddScoped<ICategorytSaveUseCase, CategorySaveUseCase>();
            service.AddScoped<ICategoryWriteOnlyUseCase, CategoryRepository>();
        }
    }
}
