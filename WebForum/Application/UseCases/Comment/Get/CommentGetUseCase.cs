using Application.Boundaries.Comment;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCases.Comment.Get
{
    public class CommentGetUseCase : ICommentGetUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly ICommentReadOnlyUseCase commentReadOnlyUseCase;

        public CommentGetUseCase(IOutputPort outputPort, ICommentReadOnlyUseCase commentReadOnlyUseCase)
        {
            this.outputPort = outputPort;
            this.commentReadOnlyUseCase = commentReadOnlyUseCase;
        }

        public void Execute(CommentGetRequest commentGetRequest)
        {
            try
            {
                var comment = commentReadOnlyUseCase.GetById(commentGetRequest.Id);
                if (comment == null)
                    throw new ArgumentException($"Comment not found for id {commentGetRequest.Id}");
                outputPort.Standard(comment);
            }
            catch (Exception ex)
            {
                outputPort.Error($"Erro while processing {ex.Message}");
            }
        }
    }
}
