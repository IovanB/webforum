using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ITokenRepository
    {
        object GetByName(string name, string password);
    }
}
