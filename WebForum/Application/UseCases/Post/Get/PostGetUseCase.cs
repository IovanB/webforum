using Application.Boundaries.Post;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCases.Post.Get
{
    public class PostGetUseCase : IPostGetUseCase
    {
        private readonly IOutputPort output;
        private readonly IPostReadOnlyUseCase postReadOnlyUseCase;

        public PostGetUseCase(IOutputPort output, IPostReadOnlyUseCase postReadOnlyUseCase)
        {
            this.output = output;
            this.postReadOnlyUseCase = postReadOnlyUseCase;
        }
        public void Execute(PostGetRequest request)
        {
            try
            {
                var req = postReadOnlyUseCase.GetById(request.Id);
                if (req == null)
                    throw new ArgumentException("There is no post");
                output.Standard(request.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Erro while processing Post {ex.Message}");
            }
        }
    }
}
