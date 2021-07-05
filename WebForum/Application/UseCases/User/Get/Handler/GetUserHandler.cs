using Application.Repositories.Common;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCases.User.Get.Handler
{
    public class GetUserHandler : Handler<UserGetRequest>
    {
        private readonly IUserReadOnlyUseCase userReadOnlyUseCase;

        public GetUserHandler(IUserReadOnlyUseCase userReadOnlyUseCase)
        {
            this.userReadOnlyUseCase = userReadOnlyUseCase;
        }
        public override void ProcessRequest(UserGetRequest request)
        {
            var req = request.Id == null ? userReadOnlyUseCase.GetByName(request.Name, request.Password) : userReadOnlyUseCase.GetById(request.Id.Value);
            if (req == null)
                throw new ArgumentException("Cannot find an user");
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
