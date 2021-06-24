using System;

namespace Application.UseCase.Category.Get
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
