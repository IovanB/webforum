using System;

namespace Application.UseCase.Category.Save
{
    public class CategoryRequest
    {
        public WebForum.Domain.Entities.Category Category { get; private set; }

        public CategoryRequest(string name)
        {
            Category = new WebForum.Domain.Entities.Category(Guid.NewGuid(),name);
        }

        public CategoryRequest(Guid id, string name)
        {
            Category = new WebForum.Domain.Entities.Category(id, name);
        }
    }
}
