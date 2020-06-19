using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.Category
{
    public interface IAddCategoryUseCase
    {
        int Add(Domain.Entities.Category category);
    }
}
