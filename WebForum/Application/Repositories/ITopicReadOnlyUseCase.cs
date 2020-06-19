using System;
using System.Collections.Generic;
using WebForum.Domain.Entities;

namespace WebForum.Application.Repositories
{
    public interface ITopicReadOnlyUseCase 
    {
        List<Topic> GetAll();
        Topic GetById(Guid id);
    }
}
