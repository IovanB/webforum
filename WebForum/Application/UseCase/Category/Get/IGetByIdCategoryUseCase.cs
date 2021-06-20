using System;

namespace Application.UseCase.Category.Get
{
    public interface IGetByIdCategoryUseCase
    {
        WebForum.Domain.Entities.Category GetById(Guid id);
    }
}
