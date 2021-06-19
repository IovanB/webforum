using System;
using System.ComponentModel.DataAnnotations;

namespace WebForum.Domain.Entities
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
