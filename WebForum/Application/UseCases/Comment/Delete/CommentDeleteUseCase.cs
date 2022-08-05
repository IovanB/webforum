using Application.Boundaries.Comment;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCases.Comment.Delete
{
    public class CommentDeleteUseCase : ICommentDeleteUseCase
    {
        private readonly IOutputPort output;
        private readonly ICommentWriteOnlyUseCase commentWriteOnlyUseCase;

        public CommentDeleteUseCase(IOutputPort output, ICommentWriteOnlyUseCase commentWriteOnlyUseCase)
        {
            this.output = output;
            this.commentWriteOnlyUseCase = commentWriteOnlyUseCase;
        }
        public void Execute(CommentDeleteRequest deleteRequest)
        {
            try
            {
                var comment = commentWriteOnlyUseCase.Remove(deleteRequest.Id);
                if (comment == 0)
                    output.Error($"Error while processing the request for ID {deleteRequest.Id}");
                
                output.Standard(deleteRequest.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Something went wrong {ex.Message}");
            }
        }
    }
}
