using System;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.User
{
    public class RemoveUserUseCase : IRemoveUserUseCase
    {
        private readonly IUserWriteOnlyUseCase userWriteOnlyUseCase;

        public int Remove(Domain.Entities.User user)
        {
            return userWriteOnlyUseCase.Remove(user);
        }

        public RemoveUserUseCase(IUserWriteOnlyUseCase userWriteOnlyUseCase)
        {
            this.userWriteOnlyUseCase = userWriteOnlyUseCase;
        }

        
    }
}
