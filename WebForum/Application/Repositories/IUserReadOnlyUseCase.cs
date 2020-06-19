using WebForum.Domain.Entities;

namespace WebForum.Application.Repositories
{
    public interface IUserReadOnlyUseCase : IReadOnlyUseCase<User>
    {
        User FindByLogin(string login);
        User GetByName(string name, string password);
    }
}
