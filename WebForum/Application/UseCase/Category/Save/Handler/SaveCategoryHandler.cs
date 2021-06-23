using Application.Repositories.Common;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCase.Category.Save.Handler
{
    public class SaveCategoryHandler : Handler<CategorytRequest>
    {
        private readonly ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase;

        public SaveCategoryHandler(ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase)
        {
            this.categoryWriteOnlyUseCase = categoryWriteOnlyUseCase;
        }
        public override void ProcessRequest(CategorytRequest request)
        {
            var req = categoryWriteOnlyUseCase.Save(request.Category);

            if (req == 0)
                throw new ArgumentException("Problem whilst adding category");
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
