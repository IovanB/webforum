using Application.Boundaries.Post;
using Application.UseCase.Post.Save.Handler;
using System;

namespace Application.UseCase.Post.Save
{
    public class PostSaveUseCase : IPostSaveUseCase
    {
        private readonly IOutputPort output;
        private readonly ValidateHandler validateHandler;

        public PostSaveUseCase(IOutputPort output,ValidateHandler validateHandler, SavePostHandler savePostHandler)
        {
            this.output = output;
            this.validateHandler = validateHandler;
            validateHandler.SetSucessor(savePostHandler);
        }
        public void Execute(PostRequest request)
        {
            try
            {
                validateHandler.ProcessRequest(request);
                output.Standard(request.Post.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Something went wrong while processing {ex.Message}");
            }
        }
    }
}
