using System;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.User
{
    public class AddUserUseCase : IAddUserUseCase
    {
        private readonly IUserWriteOnlyUseCase userWriteOnlyUseCase;

        public int Add(Domain.Entities.User user)
        {
            return userWriteOnlyUseCase.Add(user);
        }
        public AddUserUseCase(IUserWriteOnlyUseCase userWriteOnlyUseCase)
        {
            this.userWriteOnlyUseCase = userWriteOnlyUseCase;
        }

      
    }
}
