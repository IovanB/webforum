using System;
using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Post.Update
{
    public class PostInput
    {
        [Required]
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}
