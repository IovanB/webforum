﻿using Application.Boundaries.Category;
using Application.UseCase.Category.Save.Handler;
using System;

namespace Application.UseCase.Category.Save
{
    public class CommentSaveUseCase : ICommentSaveUseCase
    {
        private readonly IOutputPort outputPort;
        private readonly ValidateHandler validateHandler;

        public CommentSaveUseCase(IOutputPort outputPort, ValidateHandler validateHandler, SaveCommentHandler saveCategoryHandler)
        {
            this.outputPort = outputPort;
            this.validateHandler = validateHandler;
            this.validateHandler.SetSucessor(saveCategoryHandler);
        }
        public void Execute(CommentRequest request)
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
