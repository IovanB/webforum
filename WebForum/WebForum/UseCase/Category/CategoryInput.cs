using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Category
{
    public class CategoryInput
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
