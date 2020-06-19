using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.Topic
{
    public interface IUpdateTopicUseCase
    {
        int Update(Domain.Entities.Topic topic);
    }
}
