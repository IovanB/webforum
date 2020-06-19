using WebForum.Domain.Entities;

namespace WebForum.Application.Repositories
{
    public interface ITopicWriteOnlyUseCase
    {
        int Add(Topic topic);
        int Remove(Topic topic);
        int Update(Topic topic);
    }
}
