using Application.Repositories.Common;
using System;

namespace Application.UseCases.Comment.Save.Handler
{
    public class ValidateHandler : Handler<CommentRequest>
    {
        public override void ProcessRequest(CommentRequest request)
        {
            if (!request.Comment.IsValid)
                throw new ArgumentException("Invalid Model");
            
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
