
using System;
using System.Collections.Generic;

namespace Application.Boundaries.Comment
{
    public interface IOutputPort
    {
        void Standard(Guid id);

        void Standard(WebForum.Domain.Entities.Comment comment);

        void Standard(IList<WebForum.Domain.Entities.Comment> comment);

        void NotFound(string message);

        void Error(string message);
    }
}
