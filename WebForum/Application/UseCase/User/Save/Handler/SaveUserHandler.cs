using Application.Repositories.Common;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCase.User.Save.Handler
{
    public class SaveUserHandler : Handler<UserSaveRequest>
    {
        private readonly IUserWriteOnlyUseCase userWriteOnlyUseCase;

        public SaveUserHandler(IUserWriteOnlyUseCase userWriteOnlyUseCase)
        {
            this.userWriteOnlyUseCase = userWriteOnlyUseCase;
        }
        public override void ProcessRequest(UserSaveRequest request)
        {
            var req = userWriteOnlyUseCase.Save(request.User);
            if (req == 0)
                throw new ArgumentException("Cannot save User");
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
