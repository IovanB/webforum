using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebForumApi.UseCase.Category.Delete
{
    public class CategoryInput
    {
        [Required]
        public Guid Id { get; set; }
    }
}
