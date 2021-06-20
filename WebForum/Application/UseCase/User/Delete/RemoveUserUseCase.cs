using System;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.User
{
    public class RemoveUserUseCase
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
