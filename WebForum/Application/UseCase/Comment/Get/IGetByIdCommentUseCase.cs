using System;

namespace Application.UseCase.Comment.Get
{
    public interface IGetByIdCommentUseCase
    {
        WebForum.Domain.Entities.Comment GetById(Guid id);
    }
}
