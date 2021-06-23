
using System;
using System.Collections.Generic;

namespace Application.Boundaries.Post
{
    public interface IOutputPort
    {
        void Standard(Guid id);

        void Standard(Domain.Entities.Post post);

        void Standard(IList<Domain.Entities.Post> post);

        void NotFound(string message);

        void Error(string message);
    }
}
