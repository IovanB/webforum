using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.Category
{
    public interface IRemoveCategoryUseCase
    {
        int Remove(Domain.Entities.Category category);
    }
}
