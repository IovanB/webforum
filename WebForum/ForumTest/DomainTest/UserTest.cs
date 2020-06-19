using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Domain.Entities;
using Xunit;

namespace ForumTest.DomainTest
{
    public class UserTest
    {
        [Fact]
        public void CreateUser()
        {
            var expectedObjects = new
            {
                Name = "Nome",
                Email = "email@naosei.com",
                Password = "12345678"
            };
            var user = new User(expectedObjects.Name, expectedObjects.Email, expectedObjects.Password);
            expectedObjects.ToExpectedObject().ShouldMatch(user);
        }

        }
}
