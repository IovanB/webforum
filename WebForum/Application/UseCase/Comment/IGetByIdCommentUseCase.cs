using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.Comment
{
    public interface IGetByIdCommentUseCase
    {
        Domain.Entities.Comment GetById(Guid id);
    }
}
