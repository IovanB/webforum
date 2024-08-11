using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Comment 
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; private set; }
        [Required]
        public int PostId { get; set; }
        public Comment(int id, string content, int postId)
        {
            Id = id;
            Content = content;
            PostId = postId;
        }
    }
}
