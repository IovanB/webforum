using Application.Repositories.Common;
using System;

namespace Application.UseCase.User.Save.Handler
{
    public class ValideUserRequest : Handler<UserSaveRequest>
    {
        public override void ProcessRequest(UserSaveRequest request)
        {
            if (!request.User.IsValid)
                throw new ArgumentException("Invalid Model");
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
