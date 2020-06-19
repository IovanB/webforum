using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebForum.Domain.Validators;

namespace WebForum.Domain.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public Guid Id{ get; private set; }
        public string Name { get; private set; }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
          
        }
        public Category(Guid id)
        {
            Id = id;
        }
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Category()
        {

        }
    }
}
