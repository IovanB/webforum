using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.Repositories;
using WebForum.Application.UseCase.Comment;
using WebForum.Domain.Entities;
using Xunit;

namespace ForumTest.ApplicationTest
{
    public class CommentUseCaseTest
    {

        [Fact]
        public void AddComment()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var user = new User("Nome1", "nome1@nome1.com", "1345678");
            var post = new Post("Nova Category", "Postando algo irrelevante", topic, user);
            var comment = new Comment("New Comment", post, user);
            var commentRepositoryMock = new Mock<ICommentWriteOnlyUseCase>();
            var commentAddUseCase = new AddCommentUseCase(commentRepositoryMock.Object);
            commentAddUseCase.Add(comment);
            commentRepositoryMock.Verify(x => x.Add(It.IsAny<Comment>()));
        }

        [Fact]
        public void UpdateComment()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var user = new User("Nome1", "nome1@nome1.com", "1345678");
            var post = new Post("Nova Category", "Postando algo irrelevante", topic, user);
            var comment = new Comment("New Comment", post, user);
            var commentRepositoryMock = new Mock<ICommentWriteOnlyUseCase>();
            var commentUpdateUseCase = new UpdateCommentUseCase(commentRepositoryMock.Object);
            commentUpdateUseCase.Update(comment);
            commentRepositoryMock.Verify(x => x.Update(It.IsAny<Comment>()));
        }

        [Fact]
        public void RemoveComment()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var user = new User("Nome1", "nome1@nome1.com", "1345678");
            var post = new Post("Nova Category", "Postando algo irrelevante", topic, user);
            var comment = new Comment("New Comment", post, user);
            var commentRepositoryMock = new Mock<ICommentWriteOnlyUseCase>();
            var commentRemoveUseCase = new RemoveCommentUseCase(commentRepositoryMock.Object);
            commentRemoveUseCase.Remove(comment);
            commentRepositoryMock.Verify(x => x.Remove(It.IsAny<Comment>()));

        }
        [Fact]
        public void GetAllComment()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var user = new User("Nome1", "nome1@nome1.com", "1345678");
            var post = new Post("Nova Category", "Postando algo irrelevante", topic, user);
            var comment = new Comment("New Comment", post, user);
            var commentRepositoryMock = new Mock<ICommentReadOnlyUseCase>();
            var commentGetAllUseCase = new GetAllCommentUseCase(commentRepositoryMock.Object);
            commentGetAllUseCase.GetAll();
            commentRepositoryMock.Verify(x => x.GetAll());

        }

        [Fact]
        public void GetByIdComment()
        {
            var category = new Category("Nova Category");
            var topic = new Topic("Nova Category", category);
            var user = new User("Nome1", "nome1@nome1.com", "1345678");
            var post = new Post("Nova Category", "Postando algo irrelevante", topic, user);
            var comment = new Comment("New Comment", post, user);
            var commentRepositoryMock = new Mock<ICommentReadOnlyUseCase>();
            var commentGetByIdUseCase = new GetByIdCommentUseCase(commentRepositoryMock.Object);
            commentGetByIdUseCase.GetById(comment.Id);
            commentRepositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()));

        }
    }
}
