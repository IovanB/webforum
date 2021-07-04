using System;
using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Post.Add
{
    public class PostInput
    {
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public Guid TopicId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
