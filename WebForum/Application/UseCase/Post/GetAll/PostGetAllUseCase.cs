using Application.Boundaries.Post;
using Application.Repositories.Interfaces;
using System;


namespace Application.UseCase.Post.GetAll
{
    public class PostGetAllUseCase : IPostGetAllUseCase
    {
        private readonly IOutputPort output;
        private readonly IPostReadOnlyUseCase postReadOnlyUseCase;

        public PostGetAllUseCase(IOutputPort output, IPostReadOnlyUseCase postReadOnlyUseCase)
        {
            this.output = output;
            this.postReadOnlyUseCase = postReadOnlyUseCase;
        }
        public void Execute()
        {
            try
            {
                var req = postReadOnlyUseCase.GetAll();
                output.Standard(req);
            }
            catch (Exception ex)
            {
                output.Error($"Error while processing {ex.Message}");
            }
        }
    }
}
