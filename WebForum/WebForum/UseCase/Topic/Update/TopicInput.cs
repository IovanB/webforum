using System;
using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Topic.Update
{
    public class TopicInput
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
