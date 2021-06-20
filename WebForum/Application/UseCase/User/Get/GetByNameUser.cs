using Application.Repositories.UserRepository;

namespace WebForum.Application.UseCase.User
{
    public class GetByNameUser : IGetByNameUser
    {
        private readonly IWriteOnlyUserRepositoryUseCase userReadOnlyUseCase;

        public Domain.Entities.User GetByName(string name, string password)
        {
            return userReadOnlyUseCase.GetByName(name, password);
        }
        public GetByNameUser(IWriteOnlyUserRepositoryUseCase userReadOnlyUseCase)
        {
            this.userReadOnlyUseCase = userReadOnlyUseCase;
        }
    }
}
