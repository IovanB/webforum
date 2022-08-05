using Application.Repositories.Common;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCases.Post.Save.Handler
{
    public class SavePostHandler : Handler<PostRequest>
    {
        private readonly IPostWriteOnlyUseCase postWriteOnlyUseCase;

        public SavePostHandler(IPostWriteOnlyUseCase postWriteOnlyUseCase)
        {
            this.postWriteOnlyUseCase = postWriteOnlyUseCase;
        }
        public override void ProcessRequest(PostRequest request)
        {
            var req = postWriteOnlyUseCase.Save(request.Post);
            if (req == 0)
                throw new ArgumentException("Problem while adding Post");
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
