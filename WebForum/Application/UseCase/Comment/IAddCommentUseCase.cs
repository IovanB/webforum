using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.Comment
{
    public interface IAddCommentUseCase
    {
        int Add(Domain.Entities.Comment comment);
    }
}
