using Application.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Category.Save.Handler
{
    public class ValidateHandler : Handler<CategorySaveRequest>
    {
        public override void ProcessRequest(CategorySaveRequest request)
        {
            if (!request.Category.IsValid)
                throw new ArgumentException("Invalid Model");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}

