using System;
using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Post.Delete
{
    public class PostInput
    {
        [Required]
        public Guid Id { get; set; }
    }
}
