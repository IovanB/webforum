using System;

namespace Application.UseCase.Comment.Save
{
    public class CommentRequest
    {
        public Domain.Entities.Comment Comment { get; private set; }
        public string Content { get; private set; }
        public Guid PostId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid Id { get; private set; }
        public CommentRequest(string content, Domain.Entities.Post post, Domain.Entities.User user)
        {
            Comment = new Domain.Entities.Comment(content, post, user);
        }
        public CommentRequest(Guid id, string content, Guid postId, Guid userId)
        {
            Id = id;
            Content = content;
            PostId = postId;
            UserId = userId;
        }

    }
}
