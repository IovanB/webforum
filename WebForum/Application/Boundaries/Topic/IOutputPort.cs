
using System;
using System.Collections.Generic;

namespace Application.Boundaries.Topic
{
    public interface IOutputPort
    {
        void Standard(Guid id);

        void Standard(Domain.Entities.Topic topic);

        void Standard(IList<Domain.Entities.Topic> topic);

        void NotFound(string message);

        void Error(string message);
    }
}
