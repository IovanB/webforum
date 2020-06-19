using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.User
{
    public interface IGetAllUserUseCase
    {
        List<Domain.Entities.User> GetAll();
    }
}
