using Moq;
using System;
using WebForum.Application.Repositories;
using WebForum.Application.UseCase.Topic;
using WebForum.Domain.Entities;
using Xunit;

namespace ForumTest.ApplicationTest
{
    public class TopicUseCaseTest
    {
        [Fact]
        public void AddTopic()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var topicRepositoryMock = new Mock<ITopicWriteOnlyUseCase>();
            var topicAddUseCase = new AddTopicUseCase(topicRepositoryMock.Object);
            topicAddUseCase.Add(topic);
            topicRepositoryMock.Verify(x => x.Add(It.IsAny<Topic>()));
        }

        [Fact]
        public void UpdateTopic()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var topicRepositoryMock = new Mock<ITopicWriteOnlyUseCase>();
            var topicUpdateUseCase = new UpdateTopicUseCase(topicRepositoryMock.Object);
            topicUpdateUseCase.Update(topic);
            topicRepositoryMock.Verify(x => x.Update(It.IsAny<Topic>()));
        }
        [Fact]
        public void RemoveTopic()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var topicRepositoryMock = new Mock<ITopicWriteOnlyUseCase>();
            var topicRemoveUseCase = new RemoveTopicUseCase(topicRepositoryMock.Object);
            topicRemoveUseCase.Remove(topic);
            topicRepositoryMock.Verify(x => x.Remove(It.IsAny<Topic>()));
        }
        [Fact]
        public void GetAllTopic()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var topicRepositoryMock = new Mock<ITopicReadOnlyUseCase>();
            var topicGetAllUseCase = new GetAllTopicUseCase(topicRepositoryMock.Object);
            topicGetAllUseCase.GetAll();
            topicRepositoryMock.Verify(x => x.GetAll());
        }
        [Fact]
        public void GetByIdTopic()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var topicRepositoryMock = new Mock<ITopicReadOnlyUseCase>();
            var topicGetByIdUseCase = new GetByIdTopicUseCase(topicRepositoryMock.Object);
            topicGetByIdUseCase.GetById(topic.Id);
            topicRepositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()));
        }
    }
}
