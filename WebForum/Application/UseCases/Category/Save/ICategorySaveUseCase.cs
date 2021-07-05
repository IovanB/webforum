using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Category.Save
{
    public interface ICategorySaveUseCase
    {
        void Execute(CategorySaveRequest request);
    }
}
