using Application.Boundaries.User;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCases.User.GetAll
{
    public class UseGetAllUseCase : IUserGetAllUseCase
    {
        private readonly IOutputPort output;
        private readonly IUserReadOnlyUseCase userReadOnlyUseCase;

        public UseGetAllUseCase(IOutputPort output, IUserReadOnlyUseCase userReadOnlyUseCase )
        {
            this.output = output;
            this.userReadOnlyUseCase = userReadOnlyUseCase;
        }
        public void Execute()
        {
            try
            {
                var req = userReadOnlyUseCase.GetAll();
                output.Standard(req);
            }
            catch (Exception ex)
            {
                output.Error($"Erro while processing {ex.Message}");
            }
        }
    }
}
