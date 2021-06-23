﻿using System;

namespace Application.UseCase.User.Delete
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
