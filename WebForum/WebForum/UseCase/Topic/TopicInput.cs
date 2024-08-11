using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Topic
{
    public class TopicInput
    {
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
