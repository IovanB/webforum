using System;
using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Topic.Add
{
    public class TopicInput
    {
        [Required]
        public Guid CategoryId { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
