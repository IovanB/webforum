using System.Collections.Generic;

namespace Application.UseCase.Comment.Get
{
    public interface IGetAllCommentUseCase
    {
        List<WebForum.Domain.Entities.Comment> GetAll();
    }
}
