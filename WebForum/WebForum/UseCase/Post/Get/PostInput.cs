using System;
using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Post.Get
{
    public class PostInput
    {
        [Required]
        public Guid Id { get; set; }
    }
}
