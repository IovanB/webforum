using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.User
{
    public class AddUserUseCase 
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.User> userWriteOnlyUseCase;

        public int Add(Domain.Entities.User user)
        {
            return userWriteOnlyUseCase.Add(user);
        }
        public AddUserUseCase(IWriteOnlyUseCase<Domain.Entities.User> userWriteOnlyUseCase)
        {
            this.userWriteOnlyUseCase = userWriteOnlyUseCase;
        }
    }
}
