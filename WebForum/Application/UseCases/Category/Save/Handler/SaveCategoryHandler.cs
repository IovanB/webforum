using Application.Repositories.Common;
using Application.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Category.Save.Handler
{
    public class SaveCategoryHandler : Handler<CategorySaveRequest>
    {
        private readonly ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase;

        public SaveCategoryHandler(ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase)
        {
            this.categoryWriteOnlyUseCase = categoryWriteOnlyUseCase;
        }
        public override void ProcessRequest(CategorySaveRequest request)
        {
            var req = categoryWriteOnlyUseCase.Save(request.Category);

            if (req == 0)
                throw new ArgumentException("Problem whilst adding category");
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
