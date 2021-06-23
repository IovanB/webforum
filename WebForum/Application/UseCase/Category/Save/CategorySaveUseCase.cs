using Application.Boundaries.Category;
using Application.UseCase.Category.Save.Handler;
using System;

namespace Application.UseCase.Category.Save
{
    public class CategorySaveUseCase : ICategorytSaveUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly ValidateHandler validateHandler;

        public CategorySaveUseCase(IOutputPort outputPort, ValidateHandler validateHandler, SaveCategoryHandler saveCategoryHandler)
        {
            this.outputPort = outputPort;
            this.validateHandler = validateHandler;
            this.validateHandler.SetSucessor(saveCategoryHandler);
        }
        public void Execute(CategorytRequest request)
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
