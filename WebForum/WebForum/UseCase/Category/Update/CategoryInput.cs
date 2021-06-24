using System;
using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Category.Update
{
    public class CategoryInput
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
