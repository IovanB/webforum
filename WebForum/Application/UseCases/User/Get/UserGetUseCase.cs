using Application.Boundaries.User;
using Application.UseCases.User.Get.Handler;
using System;

namespace Application.UseCases.User.Get
{
    public class UserGetUseCase : IUserGetUseCase
    {
        private readonly IOutputPort output;
        private readonly GetUserHandler getUserHandler;

        public UserGetUseCase(IOutputPort output, GetUserHandler getUserHandler)
        {
            this.output = output;
            this.getUserHandler = getUserHandler;
        }
        public void Execute(UserGetRequest request)
        {
            try
            {
                getUserHandler.ProcessRequest(request);
                output.Standard(request.Id.Value);
            }
            catch (Exception ex)
            {
                output.Error($"Error while processing {ex.Message}");
            }
        }
    }
}
