using System;

namespace Infrastructure.Data.Entity.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public Topic Topic { get; set; }
        public string Name { get; set; }
    }
}
