using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Category.Add
{
    public class CategoryInput
    {
        [Required]
        public string Name { get; set; }
    }
}
