using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.Repositories;
using WebForum.Application.UseCase.Category;
using WebForum.Domain.Entities;
using Xunit;

namespace ForumTest.ApplicationTest
{
    public class CategoryUseCaseTest
    { 
        [Fact]
        public void AddCategory()
        {
            var category = new Category("Nova Category");
            var categoryRepositoryMock = new Mock<ICategoryWriteOnlyUseCase>();
            var categoryAddUseCase = new AddCategoryUseCase(categoryRepositoryMock.Object);
            categoryAddUseCase.Add(category);
            categoryRepositoryMock.Verify(x => x.Add(It.IsAny<Category>()));
        }

        [Fact]
        public void UpdateCategory()
        {
            var category = new Category("Nova Category");
            var categoryRepositoryMock = new Mock<ICategoryWriteOnlyUseCase>();
            var categoryUpdateUseCase = new UpdateCategoryUseCase(categoryRepositoryMock.Object);
            categoryUpdateUseCase.Update(category);
            categoryRepositoryMock.Verify(x => x.Update(It.IsAny<Category>()));
        }

        [Fact]
        public void RemoveCategory()
        {
            var category = new Category("Nova Category");
            var categoryRepositoryMock = new Mock<ICategoryWriteOnlyUseCase>();
            var categoryRemoveUseCase = new RemoveCategoryUseCase(categoryRepositoryMock.Object);
            categoryRemoveUseCase.Remove(category);
            categoryRepositoryMock.Verify(x => x.Remove(It.IsAny<Category>()));
        }
        [Fact]
        public void GetAllCategory()
        {
            var categoryRepositoryMock = new Mock<ICategoryReadOnlyUseCase>();
            var categoryGetAllUseCase = new GetAllCategoryUseCase(categoryRepositoryMock.Object);
            categoryGetAllUseCase.GetAll();
            categoryRepositoryMock.Verify(x => x.GetAll());
        }

        [Fact]
        public void GetByIdCategory()
        {
            var category = new Category("Nova Category");
            var categoryRepositoryMock = new Mock<ICategoryReadOnlyUseCase>();
            var categoryGetAllUseCase = new GetByIdCategoryUseCase(categoryRepositoryMock.Object);
            categoryGetAllUseCase.GetById(category.Id);
            categoryRepositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()));
        }
    }
}
