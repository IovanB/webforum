using System;

namespace Application.UseCase.Category.Save
{
    public class CategorytRequest
    {
        public WebForum.Domain.Entities.Category Category { get; private set; }
        public CategorytRequest(string name)
        {
            Category = new WebForum.Domain.Entities.Category(Guid.NewGuid(), name);
        }

        public CategorytRequest(Guid id, string name)
        {
            Category = new WebForum.Domain.Entities.Category(id, name);
        }
    }
}
