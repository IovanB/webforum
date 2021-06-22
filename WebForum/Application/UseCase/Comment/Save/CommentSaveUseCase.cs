using Application.Boundaries.Comment;
using Application.UseCase.Comment.Save.Handler;
using System;

namespace Application.UseCase.Comment.Save
{
    public class CommentSaveUseCase : ICommentSaveUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly ValidateHandler validateHandler;

        public CommentSaveUseCase(IOutputPort outputPort, ValidateHandler validateHandler, SaveCommentHandler saveCommentHandler)
        {
            this.outputPort = outputPort;
            this.validateHandler = validateHandler;
            this.validateHandler.SetSucessor(saveCommentHandler);
        }
        public void Execute(CommentRequest request)
        {
            try
            {
                validateHandler.ProcessRequest(request);
                outputPort.Standard(request.Comment.Id);
            }
            catch (Exception ex)
            {
                outputPort.Error($"Error while processing {ex.Message}");
            }
        }
    }
}
