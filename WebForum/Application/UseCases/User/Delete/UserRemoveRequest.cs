using System;

namespace Application.UseCases.User.Delete
{
    public class UserRemoveRequest
    {
        public Guid Id { get; private set; }

        public UserRemoveRequest(Guid id)
        {
            Id = id;
        }
    }
}
