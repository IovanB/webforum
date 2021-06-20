using Application.Repositories.Common;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCase.Category.Save.Handler
{
    public class SaveCategoryHandler : Handler<CategoryRequest>
    {
        private readonly ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase;

        public SaveCategoryHandler(ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase)
        {
            this.categoryWriteOnlyUseCase = categoryWriteOnlyUseCase;
        }
        public override void ProcessRequest(CategoryRequest request)
        {
            var req = categoryWriteOnlyUseCase.Add(request.Category);

            if (req == 0)
                throw new ArgumentException("Problem do add category");
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
