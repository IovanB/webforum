using System;

namespace Application.UseCases.Comment.Get
{
    public class CommentGetRequest
    {
        public Guid Id { get; private set; }

        public CommentGetRequest(Guid id)
        {
            Id = id;
        }

    }
}
