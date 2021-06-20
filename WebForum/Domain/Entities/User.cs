using System;
using WebForum.Domain.Validators;

namespace WebForum.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public DateTime Birthday { get; private set; }

        public string Password { get; private set; }
        //public int UserType { get; private set; }

        public User(string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            //UserType = 0;
            new UserValidator();
        }
    }
}
