using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.User
{
    public class UpdateUserUseCase 
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.User> userWriteOnlyUseCase;

        public int Update(Domain.Entities.User user)
        {
            return userWriteOnlyUseCase.Update(user);
        }

        public UpdateUserUseCase(IWriteOnlyUseCase<Domain.Entities.User> userWriteOnlyUseCase)
        {
            this.userWriteOnlyUseCase = userWriteOnlyUseCase;
        }
    }
}
