using Application.Repositories.Common;
using System;

namespace Application.UseCase.Category.Save.Handler
{
    public class ValidateHandler : Handler<CategorytRequest>
    {
        public override void ProcessRequest(CategorytRequest request)
        {
            if (!request.Category.IsValid)
                throw new ArgumentException("Invalid Model");
            
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
