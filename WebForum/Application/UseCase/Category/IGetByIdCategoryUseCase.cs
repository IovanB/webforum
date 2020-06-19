using System;

namespace WebForum.Application.UseCase.Category
{
    public interface IGetByIdCategoryUseCase
    {
        Domain.Entities.Category GetById(Guid id);
    }
}
