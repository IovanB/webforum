using System.Collections.Generic;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.User
{
    public class GetAllUserUseCase : IGetAllUserUseCase
    {
        private readonly IUserReadOnlyUseCase userReadOnlyUseCase;

        public List<Domain.Entities.User> GetAll()
        {
            return userReadOnlyUseCase.GetAll();
        }

        public GetAllUserUseCase(IUserReadOnlyUseCase userReadOnlyUseCase)
        {
            this.userReadOnlyUseCase = userReadOnlyUseCase;
        }
    }
}
