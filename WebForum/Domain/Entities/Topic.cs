using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebForum.Domain.Entities
        
{
    [Table("Topic")]
    public class Topic
    {
        [Key]
        public Guid Id { get; private set; }
        
        public string Name{ get; private set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; private set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdateTime { get; private set; }

        public Category Category { get; set; }

        public Topic(string name, Category category)
        {
            Id = Guid.NewGuid();
            Name = name;
            Category = category;
            CreatedAt = DateTime.Now;
            UpdateTime = DateTime.Now;
        }


        public Topic(Guid id, string name, DateTime createdAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            UpdateTime = DateTime.Now;
        }
        public Topic()
        {

        }
    }
}
