using System.Collections.Generic;

namespace Application.UseCase.Topic.Get
{
    public interface IGetAllTopicUseCase
    {
        List<WebForum.Domain.Entities.Topic> GetAll();
    }
}
