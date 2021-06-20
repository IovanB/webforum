using System;

namespace Application.UseCase.User.Get
{
    public interface IGetByIdUserUseCase
    {
        WebForum.Domain.Entities.User GetById(Guid id);
    }
}
