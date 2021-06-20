using Application.Boundaries.Category;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCase.Category.GetAll
{
    public class CategoryGetAllUseCase : ICategoryGetAllUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly ICategoryReadOnlyUseCase categoryReadOnlyUseCase;

        public CategoryGetAllUseCase(IOutputPort outputPort, ICategoryReadOnlyUseCase categoryReadOnlyUseCase)
        {
            this.outputPort = outputPort;
            this.categoryReadOnlyUseCase = categoryReadOnlyUseCase;
        }
        public void Execute()
        {
            try
            {
                var category = categoryReadOnlyUseCase.GetAll();
                outputPort.Standard(category);
            }
            catch (Exception ex)
            {
                outputPort.Error($"Error while processing {ex.Message}");
            }
        }
    }
}
