using Application.Boundaries.Category;
using Application.UseCases.Category.Save.Handler;
using System;

namespace Application.UseCases.Category.Save
{
    public class CategorySaveUseCase : ICategorySaveUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly ValidateHandler validateHandler;

        public CategorySaveUseCase(IOutputPort outputPort, ValidateHandler validateHandler, SaveCategoryHandler saveCategoryHandler)
        {
            this.outputPort = outputPort;
            this.validateHandler = validateHandler;
            this.validateHandler.SetSucessor(saveCategoryHandler);
        }
        public void Execute(CategorySaveRequest request)
        {
            try
            {
                validateHandler.ProcessRequest(request);
                outputPort.Standard(request.Category.Id);
            }
            catch (Exception ex)
            {
                outputPort.Error($"Error while processing {ex.Message}");
            }
        }
    }
}
