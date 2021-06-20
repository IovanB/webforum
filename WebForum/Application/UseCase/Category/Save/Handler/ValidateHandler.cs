using Application.Repositories.Common;
using System;

namespace Application.UseCase.Category.Save.Handler
{
    public class ValidateHandler : Handler<CategoryRequest>
    {
        public override void ProcessRequest(CategoryRequest request)
        {
            if (!request.Category.IsValid)
                throw new ArgumentException("Invalid Model");
            
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
