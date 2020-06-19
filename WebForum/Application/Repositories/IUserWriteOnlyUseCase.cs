using WebForum.Domain.Entities;

namespace WebForum.Application.Repositories
{
    public interface IUserWriteOnlyUseCase : IWriteOnlyUseCase<User>
    {
    }
}
