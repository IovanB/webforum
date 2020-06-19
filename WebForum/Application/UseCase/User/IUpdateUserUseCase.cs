using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.User
{
    public interface IUpdateUserUseCase
    {
        int Update(Domain.Entities.User user);
    }
}
