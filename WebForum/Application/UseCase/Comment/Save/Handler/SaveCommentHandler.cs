using Application.Repositories.Common;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCase.Comment.Save.Handler
{
    public class SaveCommentHandler : Handler<CommentRequest>
    {
        private readonly ICommentWriteOnlyUseCase commentWriteOnlyUseCase;
        private readonly IPostReadOnlyUseCase postReadOnlyUseCase;
        private readonly IUserReadOnlyUseCase userReadOnlyUseCase;

        public SaveCommentHandler(ICommentWriteOnlyUseCase commentWriteOnlyUseCase, IPostReadOnlyUseCase postReadOnlyUseCase, IUserReadOnlyUseCase userReadOnlyUseCase)
        {
            this.commentWriteOnlyUseCase = commentWriteOnlyUseCase;
            this.postReadOnlyUseCase = postReadOnlyUseCase;
            this.userReadOnlyUseCase = userReadOnlyUseCase;
        }
        public override void ProcessRequest(CommentRequest request)
        {
            var post = postReadOnlyUseCase.GetById(request.PostId);
            var user = userReadOnlyUseCase.GetById(request.UserId);
            var commentRequest = new CommentRequest(request.Content, post, user);
            var req = commentWriteOnlyUseCase.Save(commentRequest.Comment);

            if (req == 0)
                throw new ArgumentException("Problem whilst adding comment");
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
