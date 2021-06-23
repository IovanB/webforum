using Application.Repositories;

namespace Application.Repositories.UserRepository
{
    public interface IWriteOnlyUserRepositoryUseCase : IWriteOnlyUseCase<Domain.Entities.User>
    {
        Domain.Entities.User GetByName(string name, string password);
    }
}
