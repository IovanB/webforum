using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.Topic
{
    public interface IGetAllTopicUseCase
    {
        List<Domain.Entities.Topic> GetAll();
    }
}
