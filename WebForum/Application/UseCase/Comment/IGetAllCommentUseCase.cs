using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.Comment
{
    public interface IGetAllCommentUseCase
    {
        public List<Domain.Entities.Comment> GetAll();
    }
}
