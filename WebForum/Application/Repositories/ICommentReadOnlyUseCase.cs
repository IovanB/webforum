using System;
using System.Collections.Generic;
using WebForum.Domain.Entities;

namespace WebForum.Application.Repositories
{
    public interface ICommentReadOnlyUseCase 
    {
        List<Comment> GetAll();
        Comment GetById(Guid id);
    }
}
