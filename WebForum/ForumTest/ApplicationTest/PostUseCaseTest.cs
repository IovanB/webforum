using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.Repositories;
using WebForum.Application.UseCase.Post;
using WebForum.Domain.Entities;
using Xunit;

namespace ForumTest.ApplicationTest
{
    public class PostUseCaseTest
    {
        [Fact]
        public void AddPost()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var user = new User("Nome1", "nome1@nome1.com", "1345678");
            var post = new Post("Nova Category","Postando algo irrelevante", topic, user);
            var postRepositoryMock = new Mock<IPostWriteOnlyUseCase>();
            var postAddUseCase = new AddPostUseCase(postRepositoryMock.Object);
            postAddUseCase.Add(post);
            postRepositoryMock.Verify(x => x.Add(It.IsAny<Post>()));
        }
        [Fact]
        public void UpdatePost()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var user = new User("Nome1", "nome1@nome1.com", "1345678");
            var post = new Post("Nova Category","Postando algo irrelevante", topic, user);
            var postRepositoryMock = new Mock<IPostWriteOnlyUseCase>();
            var postUpdateUseCase = new UpdatePostUseCase(postRepositoryMock.Object);
            postUpdateUseCase.Update(post);
            postRepositoryMock.Verify(x => x.Update(It.IsAny<Post>()));
        }
        [Fact]
        public void RemovePost()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var user = new User("Nome1", "nome1@nome1.com", "1345678");
            var post = new Post("Nova Category","Postando algo irrelevante", topic, user);
            var postRepositoryMock = new Mock<IPostWriteOnlyUseCase>();
            var postRemoveUseCase = new RemovePostUseCase(postRepositoryMock.Object);
            postRemoveUseCase.Remove(post);
            postRepositoryMock.Verify(x => x.Remove(It.IsAny<Post>()));
        }
        [Fact]
        public void GetAllPost()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var user = new User("Nome1", "nome1@nome1.com", "1345678");
            var post = new Post("Nova Category","Postando algo irrelevante", topic, user);
            var postRepositoryMock = new Mock<IPostReadOnlyUseCase>();
            var postGetAllUseCase = new GetAllPostUseCase(postRepositoryMock.Object);
            postGetAllUseCase.GetAll();
            postRepositoryMock.Verify(x => x.GetAll());
        }
        [Fact]
        public void GetByIdPost()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var user = new User("Nome1", "nome1@nome1.com", "1345678");
            var post = new Post("Nova Category","Postando algo irrelevante", topic, user);
            var postRepositoryMock = new Mock<IPostReadOnlyUseCase>();
            var postGetByIdUseCase = new GetByIdPostUseCase(postRepositoryMock.Object);
            postGetByIdUseCase.GetById(post.Id);
            postRepositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()));
        }
    }
}
