using System;

namespace Application.UseCases.Category.Get
{
    public class CategoryGetRequest
    {
        public Guid Id { get; private set; }

        public CategoryGetRequest(Guid id)
        {
            Id = id;
        }

    }
}
