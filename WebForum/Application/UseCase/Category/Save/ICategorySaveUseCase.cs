using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Category.Save
{
    public interface ICommentSaveUseCase
    {
        void Execute(CommentRequest request);
    }
}
