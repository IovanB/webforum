using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Comment
{
    public class CommentInput
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
