using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Category.Save
{
    public class CategorySaveRequest
    {
        public Domain.Entities.Category Category { get; private set; }
        public CategorySaveRequest(string name)
        {
            Category = new Domain.Entities.Category(Guid.NewGuid(), name);
        }

        public CategorySaveRequest(Guid id, string name)
        {
            Category = new Domain.Entities.Category(id, name);
        }
    }
}
