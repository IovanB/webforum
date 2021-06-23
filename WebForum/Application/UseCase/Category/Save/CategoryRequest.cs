using System;

namespace Application.UseCase.Category.Save
{
    public class CategorytRequest
    {
        public Domain.Entities.Category Category { get; private set; }
        public CategorytRequest(string name)
        {
            Category = new Domain.Entities.Category(Guid.NewGuid(), name);
        }

        public CategorytRequest(Guid id, string name)
        {
            Category = new Domain.Entities.Category(id, name);
        }
    }
}
