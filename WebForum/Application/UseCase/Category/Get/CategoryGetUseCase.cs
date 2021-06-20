using Application.Boundaries.Category;
using Application.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Category.Get
{
    public class CategoryGetUseCase : ICategoryGetUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly ICategoryReadOnlyUseCase categoryReadOnlyUseCase;

        public CategoryGetUseCase(IOutputPort outputPort, ICategoryReadOnlyUseCase categoryReadOnlyUseCase)
        {
            this.outputPort = outputPort;
            this.categoryReadOnlyUseCase = categoryReadOnlyUseCase;
        }

        public ICategoryWriteOnlyUseCase CategoryWriteOnlyUseCase { get; }

        public void Execute(CategoryGetRequest categoryGetRequest)
        {
            try
            {
                var category = categoryReadOnlyUseCase.GetById(categoryGetRequest.Id);
                if (category == null)
                    throw new ArgumentException($"Category not found for id {categoryGetRequest.Id}");
                outputPort.Standard(category);
            }
            catch (Exception ex)
            {
                outputPort.Error($"Erro while processing {ex.Message}");
            }
        }
    }
}
