using System;
using System.Collections.Generic;
using WebForum.Domain.Entities;

namespace WebForum.Application.Repositories
{
    public interface IPostReadOnlyUseCase 
    {
        List<Post> GetAll();
        Post GetById(Guid id);
    }
}
