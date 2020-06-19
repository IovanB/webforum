using ExpectedObjects;
using WebForum.Domain.Entities;
using Xunit;

namespace ForumTest.DomainTest
{
    public class CategoryTest
    {
        [Fact]
        public void CreateCategory()
        {
            var expectedCategory = new
            {
                Name = "Futebol",
            };

            var category = new Category(expectedCategory.Name);
            expectedCategory.ToExpectedObject().ShouldMatch(category);
        }
    }
}
