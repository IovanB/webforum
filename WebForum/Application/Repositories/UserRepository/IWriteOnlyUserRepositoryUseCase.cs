using WebForum.Application.Repositories;

namespace Application.Repositories.UserRepository
{
    public interface IWriteOnlyUserRepositoryUseCase : IWriteOnlyUseCase<WebForum.Domain.Entities.User>
    {
        WebForum.Domain.Entities.User GetByName(string name, string password);
    }
}
