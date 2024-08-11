using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Category(int id, string name)
    {
        [Required]
        public string Name { get; private set; } = name;
        public int Id { get; private set; } = id;   
    }
}
