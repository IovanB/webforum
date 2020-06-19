using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Category
{
    public class GetAllCategoryUseCase : IGetAllCategoryUseCase

    {
        private readonly ICategoryReadOnlyUseCase categoryReadOnlyUseCase;

        public List<Domain.Entities.Category> GetAll()
        {
            return categoryReadOnlyUseCase.GetAll();
        }
        public GetAllCategoryUseCase(ICategoryReadOnlyUseCase categoryReadOnlyUseCase)
        {
            this.categoryReadOnlyUseCase = categoryReadOnlyUseCase;
        }
    }
}
