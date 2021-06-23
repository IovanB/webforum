using Application.Boundaries.User;
using Application.Repositories.Interfaces;
using Application.UseCase.User.Delete;
using System;

namespace WebForum.Application.UseCase.User
{
    public class RemoveUserUseCase : IUserRemoveUseCase
    {
        private readonly IUserWriteOnlyUseCase userWriteOnlyUseCase;
        private readonly IOutputPort output;

        public RemoveUserUseCase(IUserWriteOnlyUseCase userWriteOnlyUseCase, IOutputPort output)
        {
            this.userWriteOnlyUseCase = userWriteOnlyUseCase;
            this.output = output;
        }

        public void Execute(UserRemoveRequest request)
        {
            try
            {
                var req = userWriteOnlyUseCase.Remove(request.Id);
                if (req == 0)
                    throw new ArgumentException("There is not user to be removed.");

                output.Standard(request.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Erro while processing {ex.Message}");
                throw;
            }
        }
    }
}
