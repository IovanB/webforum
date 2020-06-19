using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.Post
{
    public interface IAddPostUseCase
    {
        int Add(Domain.Entities.Post post);
    }
}
