using System;
using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Topic.Delete
{
    public class TopicInput
    {
        [Required]
        public Guid Id { get; set; }
    }
}
