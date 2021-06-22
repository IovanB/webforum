using Application.Boundaries.Comment;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCase.Comment.GetAll
{
    public class CommentGetAllUseCase : ICommentGetAllUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly ICommentReadOnlyUseCase commentReadOnlyUseCase;

        public CommentGetAllUseCase(IOutputPort outputPort, ICommentReadOnlyUseCase commentReadOnlyUseCase)
        {
            this.outputPort = outputPort;
            this.commentReadOnlyUseCase = commentReadOnlyUseCase;
        }
        public void Execute()
        {
            try
            {
                var comment = commentReadOnlyUseCase.GetAll();
                outputPort.Standard(comment);
            }
            catch (Exception ex)
            {
                outputPort.Error($"Error while processing {ex.Message}");
            }
        }
    }
}
