using System;
using System.Collections.Generic;

namespace Application.Boundaries.User
{
    public interface IOutputPort
    {
        void Standard(Guid id);

        void Standard(WebForum.Domain.Entities.User user);

        void Standard(IList<WebForum.Domain.Entities.User> user);

        void NotFound(string message);

        void Error(string message);
    }
}
