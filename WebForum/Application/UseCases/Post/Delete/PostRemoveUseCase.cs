using Application.Boundaries.Post;
using Application.Repositories.Interfaces;
using Application.UseCases.Post.Delete;
using System;

namespace WebForum.Application.UseCases.Post
{
    public class PostRemoveUseCase : IPostRemoveUseCase
    {
        private readonly IOutputPort output;
        private readonly IPostWriteOnlyUseCase postWriteOnlyUseCase;
        public PostRemoveUseCase(IOutputPort output, IPostWriteOnlyUseCase postWriteOnlyUseCase)
        {
            this.output = output;
            this.postWriteOnlyUseCase = postWriteOnlyUseCase;
        }

        public void Execute(PostRemoveRequest request)
        {
            try
            {
                var req = postWriteOnlyUseCase.Remove(request.Id);
                if (req == 0)
                    throw new ArgumentException("There is no post to be removed");
                output.Standard(request.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Something went wrong while processing {ex.Message}");
            }
        }

        
    }
}
