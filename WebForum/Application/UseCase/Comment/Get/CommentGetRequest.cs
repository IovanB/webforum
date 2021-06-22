using System;

namespace Application.UseCase.Comment.Get
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
