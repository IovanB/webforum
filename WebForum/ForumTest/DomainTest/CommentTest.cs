using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Domain.Entities;
using Xunit;

namespace ForumTest.DomainTest
{
    public class CommentTest
    {
        [Fact]
        public void CreateComment()
        {
            
            var category = new Category("Name");
            var topic = new Topic("Name1", category);
            var user = new User("Teste1", "teste1@teste1.com", "12345678");
            var post = new Post("Post1", "Postando isso", topic, user);

            var expectedObject = new
            {
                Content = "Este conteudo e permitido"
            };

            var comment = new Comment(expectedObject.Content, post, user);
            expectedObject.ToExpectedObject().ShouldMatch(comment);

        }
    }
}
