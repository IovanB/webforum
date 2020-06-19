using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Domain.Entities;
using Xunit;

namespace ForumTest.DomainTest
{
    public class PostTest
    {
        [Fact]
        public void CreatePost()
        {
            var category = new Category("Name");
            var topic = new Topic("Name1", category);
            var user = new User("Teste1", "teste1@teste1.com", "12345678");

            var expectedObjects = new
            {
                Title = "Testando",
                Content = "Este conteudo esta permitido"
            };

            var post = new Post(expectedObjects.Title, expectedObjects.Content, topic, user);
            expectedObjects.ToExpectedObject().ShouldMatch(post);
        }
    }
}
