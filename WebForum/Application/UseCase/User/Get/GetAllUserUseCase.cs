using System.Collections.Generic;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.User
{
    public class GetAllUserUseCase 
    {
        private readonly IReadOnlyUseCase<Domain.Entities.User> userReadOnlyUseCase;

        public List<Domain.Entities.User> GetAll()
        {
            return userReadOnlyUseCase.GetAll();
        }

        public GetAllUserUseCase(IReadOnlyUseCase<Domain.Entities.User> userReadOnlyUseCase)
        {
            this.userReadOnlyUseCase = userReadOnlyUseCase;
        }
    }
}
