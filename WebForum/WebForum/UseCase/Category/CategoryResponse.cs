using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForumApi.UseCase.Category
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public CategoryResponse(Guid id, string name, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
