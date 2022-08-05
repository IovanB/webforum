using System;

namespace WebForumApi.UseCase.Comment
{
    public class CommentResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CommentResponse(Guid id, string content, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Content = content;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
