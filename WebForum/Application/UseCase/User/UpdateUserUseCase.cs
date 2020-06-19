using WebForum.Application.UseCase.Exceptions;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.User
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly IUserWriteOnlyUseCase userWriteOnlyUseCase;

        public int Update(Domain.Entities.User user)
        {
            return userWriteOnlyUseCase.Update(user);
        }

        public UpdateUserUseCase(IUserWriteOnlyUseCase userWriteOnlyUseCase)
        {
            this.userWriteOnlyUseCase = userWriteOnlyUseCase;
        }

        
    }
}
