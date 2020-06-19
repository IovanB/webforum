using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.User
{
    public class GetByNameUser : IGetByNameUser
    {
        private readonly IUserReadOnlyUseCase userReadOnlyUseCase;

        public Domain.Entities.User GetByName(string name, string password)
        {
            return userReadOnlyUseCase.GetByName(name, password);
        }
        public GetByNameUser(IUserReadOnlyUseCase userReadOnlyUseCase)
        {
            this.userReadOnlyUseCase = userReadOnlyUseCase;
        }
    }
}
