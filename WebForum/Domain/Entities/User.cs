using System;
using Domain.Validators;

namespace Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public DateTime Birthday { get; private set; }

        public string Password { get; private set; }
        public User(string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Validate(this,new UserValidator());
        }
        public User()
        {

        }
    }
}
