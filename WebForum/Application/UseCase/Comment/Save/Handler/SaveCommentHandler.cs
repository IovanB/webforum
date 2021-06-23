using Application.Repositories.Common;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCase.Comment.Save.Handler
{
    public class SaveCommentHandler : Handler<CommentRequest>
    {
        private readonly ICommentWriteOnlyUseCase commentWriteOnlyUseCase;

        public SaveCommentHandler(ICommentWriteOnlyUseCase commentWriteOnlyUseCase)
        {
            this.commentWriteOnlyUseCase = commentWriteOnlyUseCase;
        }
        public override void ProcessRequest(CommentRequest request)
        {
            var req = commentWriteOnlyUseCase.Save(request.Comment);

            if (req == 0)
                throw new ArgumentException("Problem whilst adding comment");
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
