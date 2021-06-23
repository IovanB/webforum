using System;

namespace Application.UseCase.User.Get
{
    public class UserGetRequest
    {
        public Guid? Id { get; private set; }
        public string? Name { get; private set; }
        public string? Password { get; private set; }
        public UserGetRequest(Guid? id, string? name, string? password)
        {
            Id = id;
            Name = name;
            Password = password;
        }
    }
}
