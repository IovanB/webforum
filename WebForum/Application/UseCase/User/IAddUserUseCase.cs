using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.User
{
    public interface IAddUserUseCase
    {
        int Add(Domain.Entities.User user);
    }
}
