using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebForum.Domain.Validators;

namespace WebForum.Domain.Entities
{
    [Table("User")]
    public class User 
    {
        [Key]
        public Guid Id { get; private set; }

        public string Name { get; private set; }
        /*public string Login { get; private set; }*/

        public string Email { get; private set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthday { get; private set; }

        public string Password { get; private set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; private set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdatedAt { get; private set; }

        public int UserType { get; private set; }

        public User(string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            UserType = 0;
        }

        public User(Guid id,
            string name, 
            string email, 
            string password, 
            DateTime createdAt, 
            int userType)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            CreatedAt = createdAt;
            UpdatedAt = DateTime.Now;
            UserType = userType;
        }
       
        public User()
        {

        }
    }
}
