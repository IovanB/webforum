using Application.Boundaries.Category;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCase.Category.Delete
{
    public class CategoryDeleteUseCase : ICategoryDeleteUseCase
    {
        private readonly IOutputPort output;
        private readonly ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase;

        public CategoryDeleteUseCase(IOutputPort output, ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase)
        {
            this.output = output;
            this.categoryWriteOnlyUseCase = categoryWriteOnlyUseCase;
        }
        public void Execute(CategoryDeleteRequest deleteRequest)
        {
            try
            {
                var category = categoryWriteOnlyUseCase.Remove(deleteRequest.Id);
                if (category == 0)
                    output.Error($"Error while processing the request for ID {deleteRequest.Id}");
                
                output.Standard(deleteRequest.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Something went wrong {ex.Message}");
            }
        }
    }
}
