using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Post
    {
        public int Id { get; set; } 
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Content { get; private set; }
        [Required]
        public int TopicId { get; private set; }

        public Post(int id, string title, string content, int topicId)
        {
            Id = id;
            Title = title;
            Content = content;
            TopicId = topicId;
        }

    }
}
