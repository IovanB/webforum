using System;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.User
{
    public class GetByIdUserUseCase : IGetByIdUserUseCase
    {
        private readonly IUserReadOnlyUseCase userReadOnlyUseCase;

        public Domain.Entities.User GetById(Guid id)
        {
            return userReadOnlyUseCase.GetById(id);
        }

        public GetByIdUserUseCase(IUserReadOnlyUseCase userReadOnlyUseCase)
        {
            this.userReadOnlyUseCase= userReadOnlyUseCase;
        }

    }
}
