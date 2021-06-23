﻿using Application.Boundaries.Comment;
using System;
using System.Collections.Generic;

namespace WebForumApi.UseCase.Comment
{
    public class CommentPresenter : IOutputPort
    {
        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void NotFound(string message)
        {
            throw new NotImplementedException();
        }

        public void Standard(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Standard(Domain.Entities.Comment comment)
        {
            throw new NotImplementedException();
        }

        public void Standard(IList<Domain.Entities.Comment> comment)
        {
            throw new NotImplementedException();
        }
    }
}
