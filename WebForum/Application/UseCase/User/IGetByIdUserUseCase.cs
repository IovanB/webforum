using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.User
{
    public interface IGetByIdUserUseCase
    {
        Domain.Entities.User GetById(Guid id);
    }
}
