using System;

namespace Application.UseCases.Comment.Delete
{
    public class CommentDeleteRequest
    {
        public Guid Id { get; private set; }

        public CommentDeleteRequest(Guid id)
        {
            Id = id;
        }
    }
}
