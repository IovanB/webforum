using System.Collections.Generic;

namespace Application.UseCase.User.Get
{
    public interface IGetAllUserUseCase
    {
        List<WebForum.Domain.Entities.User> GetAll();
    }
}
