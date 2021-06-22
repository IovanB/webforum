using Application.Repositories.Common;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCase.Category.Save.Handler
{
    public class SaveCommentHandler : Handler<CommentRequest>
    {
        private readonly ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase;

        public SaveCommentHandler(ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase)
        {
            this.categoryWriteOnlyUseCase = categoryWriteOnlyUseCase;
        }
        public override void ProcessRequest(CommentRequest request)
        {
            var req = categoryWriteOnlyUseCase.Add(request.Category);

            if (req == 0)
                throw new ArgumentException("Problem whilst adding category");
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
