using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Entity.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public DateTime Birthday { get; private set; }

        public string Password { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
