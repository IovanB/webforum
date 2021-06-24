using System;
using System.ComponentModel.DataAnnotations;

namespace WebForumApi.UseCase.Category.Get
{
    public class CategoryInput
    {
        [Required]
        public Guid Id { get; set; }
    }
}
