using System.Collections.Generic;

namespace Application.UseCase.Post.Get
{
    public interface IGetAllPostUseCase
    {
        List<WebForum.Domain.Entities.Post> GetAll();
    }
}
