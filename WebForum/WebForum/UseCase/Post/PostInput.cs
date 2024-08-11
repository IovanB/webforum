using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Post
{
    public class PostInput
    {
        public int Id { get; set; }
        [Required]
        public int TopicId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
