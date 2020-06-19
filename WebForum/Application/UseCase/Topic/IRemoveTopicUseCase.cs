using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.Topic
{
    public interface IRemoveTopicUseCase
    {
        int Remove(Domain.Entities.Topic topic);
    }
}
