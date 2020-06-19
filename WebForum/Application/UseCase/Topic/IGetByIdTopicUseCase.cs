using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.Topic
{
    public interface IGetByIdTopicUseCase
    {
        Domain.Entities.Topic GetById(Guid id);
    }
}
