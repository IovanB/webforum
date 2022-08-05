using System;
using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Comment.Add
{
    public class CommentInput
    {
        [Required]
        public string Content { get; set; }
        
        [Required]
        public Guid PostId { get; set; } 
        
        [Required]
        public Guid UserId{ get; set; } 
    }
}
