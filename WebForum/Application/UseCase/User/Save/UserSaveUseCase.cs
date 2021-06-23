using Application.Boundaries.User;
using Application.UseCase.User.Save.Handler;
using System;

namespace Application.UseCase.User.Save
{
    public class UserSaveUseCase : IUserSaveUseCase
    {
        private readonly IOutputPort output;
        private readonly ValideUserRequest valideUser;

        public UserSaveUseCase(IOutputPort output, ValideUserRequest valideUser, SaveUserHandler saveUserHandler )
        {
            this.output = output;
            this.valideUser = valideUser;
            valideUser.SetSucessor(saveUserHandler);
        }
        public void Execute(UserSaveRequest request)
        {
            try
            {
                valideUser.ProcessRequest(request);
                output.Standard(request.User.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Erro while processing {ex.Message}");
            }
        }
    }
}
