using Autofac;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.UseCase.Category;
using WebForum.Application.UseCase.Topic;
using WebForum.Application.UseCase.User;
using WebForum.Domain.Entities;
using WebForum.Infrastructure.Repository;
using WebForum.WebForumApi.UseCase.Topic;
using Xunit;

namespace ForumTest.ControllersTest
{
    public class TopicControllerTest : IClassFixture<Fixed.Fixture>
    {
        public readonly IAddTopicUseCase addTopicUseCase;
        public readonly IUpdateTopicUseCase updateTopicUseCase;
        public readonly IRemoveTopicUseCase removeTopicUseCase;
        public readonly IGetAllTopicUseCase getAllTopicUseCase;
        public readonly IGetByIdTopicUseCase getByIdTopicUseCase;
        public readonly IAddCategoryUseCase addCategoryUseCase;

        public readonly TopicController topicController;
        public readonly IGetByIdCategoryUseCase getByIdCategoryUseCase;
        public readonly IGetByIdUserUseCase getByIdUserUseCase;

        public Category category { get; set; }

        public Topic topic { get; set; }
        public Guid guid;

        public TopicControllerTest(Fixed.Fixture fixture)
        {
            this.addTopicUseCase = fixture.Container.Resolve< IAddTopicUseCase>();
            this.addCategoryUseCase = fixture.Container.Resolve< IAddCategoryUseCase>();
            this.updateTopicUseCase = fixture.Container.Resolve<IUpdateTopicUseCase>();
            this.removeTopicUseCase = fixture.Container.Resolve<IRemoveTopicUseCase>();
            this.getAllTopicUseCase = fixture.Container.Resolve<IGetAllTopicUseCase>();
            this.getByIdTopicUseCase = fixture.Container.Resolve<IGetByIdTopicUseCase>();
            this.category = new Category("Teste1");
            this.topic = new Topic("Topic1", category);
            this.guid = new Guid();
            this.topicController = new TopicController(addTopicUseCase,
                getAllTopicUseCase,
                getByIdTopicUseCase,
                updateTopicUseCase,
                removeTopicUseCase,
                getByIdCategoryUseCase,
                getByIdUserUseCase

                );
        }

        [Fact]
        public void CreateTopic()
        {
            new CategoryRepository().Add(category);
            var createTopic = topicController.CreateTopic(topic.Name, topic.Category.Id);

            Assert.IsType<OkObjectResult>(createTopic);
        }
    }
}
