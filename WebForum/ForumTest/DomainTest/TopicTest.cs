using ExpectedObjects;
using WebForum.Domain.Entities;
using Xunit;

namespace ForumTest.DomainTest
{
    public class TopicTest
    {
        [Fact]
        public void CreateTopic()
        {
            var category = new Category("nome");
            var expectedTopic = new
            {
                Name = "Futebol",
                
            };

        var topic = new Topic(expectedTopic.Name, category);
            expectedTopic.ToExpectedObject().ShouldMatch(topic);
        }
    }
}
