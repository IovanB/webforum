using System;

namespace Application.UseCase.Topic.Get
{
    public interface IGetByIdTopicUseCase
    {
        WebForum.Domain.Entities.Topic GetById(Guid id);
    }
}
