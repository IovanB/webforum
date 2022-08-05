using Application.Repositories.Common;
using System;

namespace Application.UseCases.Post.Save.Handler
{
    public class ValidateHandler : Handler<PostRequest>
    {
        public override void ProcessRequest(PostRequest request)
        {
            if (!request.Post.IsValid)
                throw new ArgumentException("Invalid Model");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
