using Autofac;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.UseCase.Category;
using WebForum.Domain.Entities;
using WebForum.Infrastructure.Repository;
using WebForum.WebForumApi.UseCase.Category;
using Xunit;

namespace ForumTest.ControllersTest
{
    public class CategoryControllerTest : IClassFixture<Fixed.Fixture>
    {
        public readonly IAddCategoryUseCase addCategoryUseCase;
        public readonly IRemoveCategoryUseCase removeCategoryUseCase;
        public readonly IUpdateCategoryUseCase updateCategoryUseCase;
        public readonly IGetAllCategoryUseCase getAllCategoryUseCase;
        public readonly IGetByIdCategoryUseCase byIdCategoryUseCase;
        public CategoryController categoryController;
        public Category category { get; set; }
        public Guid guid;

        public CategoryControllerTest(Fixed.Fixture fixture)
        {
            this.addCategoryUseCase = fixture.Container.Resolve<IAddCategoryUseCase>();
            this.removeCategoryUseCase = fixture.Container.Resolve<IRemoveCategoryUseCase>();
            this.updateCategoryUseCase = fixture.Container.Resolve<IUpdateCategoryUseCase>();
            this.getAllCategoryUseCase = fixture.Container.Resolve<IGetAllCategoryUseCase>();
            this.byIdCategoryUseCase = fixture.Container.Resolve<IGetByIdCategoryUseCase>();
            this.category = new Category("Ciencia");
            this.guid = new Guid();
            this.categoryController = new CategoryController(addCategoryUseCase,
                removeCategoryUseCase,
                updateCategoryUseCase,
                getAllCategoryUseCase,
                byIdCategoryUseCase);
        }

        [Fact]
        public void CreateCategory()
        {
            var retorno = categoryController.CreateCategory(category.Name);

            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void GetAllCategory()
        {
            new CategoryRepository().Add(category);
            var getCategory = categoryController.GetAllCategory();

            Assert.IsType<OkObjectResult>(getCategory);
        }

        [Fact]
        public void GetByIdCategory()
        {
            
            var getCategory = categoryController.GetCategoryId(category.Id);

            Assert.IsType<OkObjectResult>(getCategory);
        }

        [Fact]
        public void UpdateCategory()
        {
            new CategoryRepository().Add(category);
            var getCategory = categoryController.UpdateCategory(category.Id, category.Name);

            Assert.IsType<OkObjectResult>(getCategory);
        }

        [Fact]
        public void RemoveCategory()
        {
            new CategoryRepository().Add(category);
            var getCategory = categoryController.RemoveCategory(category.Id);

            Assert.IsType<OkObjectResult>(getCategory);
        }

    }
}
