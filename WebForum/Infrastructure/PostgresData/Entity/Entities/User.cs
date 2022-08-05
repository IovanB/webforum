using System;

namespace Infrastructure.Data.Entity.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; private set; }

        public DateTime Birthday { get;  set; }

        public string Password { get;  set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Comment Comment { get; set; }
    }
}
