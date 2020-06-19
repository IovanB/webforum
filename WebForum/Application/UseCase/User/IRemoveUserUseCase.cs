using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.User
{
    public interface IRemoveUserUseCase
    {
        int Remove(Domain.Entities.User user);
    }
}
