
using System;
using System.Collections.Generic;

namespace Application.Boundaries.Post
{
    public interface IOutputPort
    {
        void Standard(Guid id);

        void Standard(WebForum.Domain.Entities.Post post);

        void Standard(IList<WebForum.Domain.Entities.Post> post);

        void NotFound(string message);

        void Error(string message);
    }
}
