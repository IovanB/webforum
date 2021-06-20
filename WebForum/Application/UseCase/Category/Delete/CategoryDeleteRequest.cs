using System;

namespace Application.UseCase.Category.Delete
{
    public class CategoryDeleteRequest
    {
        public Guid Id { get; private set; }

        public CategoryDeleteRequest(Guid id)
        {
            Id = id;
        }
    }
}
