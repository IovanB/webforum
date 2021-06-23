using WebForum.Application.Repositories;
using WebForum.Domain.Entities;

namespace Application.Repositories.Interfaces
{
    public interface IUserReadOnlyUseCase: IReadOnlyUseCase<User>
    {
        User GetByName(string name, string password);
    }
}
