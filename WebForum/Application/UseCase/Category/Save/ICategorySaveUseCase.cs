using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Category.Save
{
    public interface ICategorySaveUseCase
    {
        void Execute(CategoryRequest request);
    }
}
