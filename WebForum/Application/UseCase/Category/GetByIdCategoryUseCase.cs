using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Category
{
    public class GetByIdCategoryUseCase : IGetByIdCategoryUseCase
    {
        private readonly ICategoryReadOnlyUseCase categoryReadOnlyUseCase;

        public Domain.Entities.Category GetById(Guid id)
        {
            return categoryReadOnlyUseCase.GetById(id);
        }
        public GetByIdCategoryUseCase(ICategoryReadOnlyUseCase categoryReadOnlyUseCase)
        {
            this.categoryReadOnlyUseCase = categoryReadOnlyUseCase;
        }
    }
}
