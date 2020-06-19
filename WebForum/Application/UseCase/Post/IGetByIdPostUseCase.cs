using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.Post
{
    public interface IGetByIdPostUseCase
    {
        Domain.Entities.Post GetById(Guid id);
    }
}
