using System;

namespace Application.UseCase.Comment.Delete
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
