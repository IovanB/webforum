using System;
using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Comment.Update
{
    public class CommentInput
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Content { get; set; }
        
        [Required]
        public Guid PostId { get; set; }        
        
        [Required]
        public Guid UserId { get; set; }
    }
}
