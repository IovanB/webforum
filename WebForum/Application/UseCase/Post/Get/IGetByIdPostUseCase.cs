using System;

namespace Application.UseCase.Post.Get
{
    public interface IGetByIdPostUseCase
    {
        WebForum.Domain.Entities.Post GetById(Guid id);

    }
}
