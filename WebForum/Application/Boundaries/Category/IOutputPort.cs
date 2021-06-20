﻿
using System;
using System.Collections.Generic;

namespace Application.Boundaries.Category
{
    public interface IOutputPort
    {
        void Standard(Guid id);

        void Standard(WebForum.Domain.Entities.Category category);

        void Standard(IList<WebForum.Domain.Entities.Category> category);

        void NotFound(string message);

        void Error(string message);
    }
}
