using Application.Boundaries.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebForumApi.UseCase.Category
{
    public class CategoryPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }
        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);
        

        public void Standard(Guid id)
            => ViewModel = new OkObjectResult(id);

        public void Standard(Domain.Entities.Category category)
            => ViewModel = new OkObjectResult(new CategoryResponse(category.Id, category.Name, category.CreatedAt, category.UpdatedAt));

        public void Standard(IList<Domain.Entities.Category> category)
        {
            var categoryResponse = new List<CategoryResponse>();
            category.ToList().ForEach(s => categoryResponse.Add(new CategoryResponse(s.Id, s.Name, s.CreatedAt, s.UpdatedAt)));
            ViewModel = new OkObjectResult(categoryResponse);
        }
    }
}
