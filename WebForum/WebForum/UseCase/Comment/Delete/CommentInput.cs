using System;
using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Comment.Delete
{
    public class CommentInput
    {
        [Required]
        public Guid Id { get; set; }
    }
}
