using System.Collections.Generic;

namespace Application.UseCase.Category.Get
{
    public interface IGetAllCategoryUseCase
    {
        List<WebForum.Domain.Entities.Category> GetAll();
    }
}
