using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.Category
{
    public interface IGetAllCategoryUseCase
    {
        List<Domain.Entities.Category> GetAll();
    }
}
