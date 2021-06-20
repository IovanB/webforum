using Application.UseCase.User.Get;
using System;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.User
{
    public class GetByIdUserUseCase : IGetByIdUserUseCase
    {
        private readonly IReadOnlyUseCase<Domain.Entities.User> userReadOnlyUseCase;

        public Domain.Entities.User GetById(Guid id)
        {
            return userReadOnlyUseCase.GetById(id);
        }

        public GetByIdUserUseCase(IReadOnlyUseCase<Domain.Entities.User> userReadOnlyUseCase)
        {
            this.userReadOnlyUseCase = userReadOnlyUseCase;
        }

    }
}
