using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.Post
{
    public interface IGetAllPostUseCase
    {
        List<Domain.Entities.Post> GetAll();
    }
}
