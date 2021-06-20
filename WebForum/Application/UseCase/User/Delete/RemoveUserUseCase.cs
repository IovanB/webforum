using Application.UseCase.User.Delete;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.User
{
    public class RemoveUserUseCase : IRemoveUserUseCase
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.User> userWriteOnlyUseCase;

        public int Remove(Domain.Entities.User user)
        {
            return userWriteOnlyUseCase.Remove(user);
        }

        public RemoveUserUseCase(IWriteOnlyUseCase<Domain.Entities.User> userWriteOnlyUseCase)
        {
            this.userWriteOnlyUseCase = userWriteOnlyUseCase;
        }
    }
}
