using WebForum.Domain.Entities;

namespace WebForum.Application.Repositories
{
    public interface IPostWriteOnlyUseCase
    {
        int Add(Post post);
        int Remove(Post post);
        int Update(Post post);

    }
}
