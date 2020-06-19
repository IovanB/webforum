using Moq;
using System;
using WebForum.Application.Repositories;
using WebForum.Application.UseCase.User;
using WebForum.Domain.Entities;
using Xunit;

namespace ForumTest.ApplicationTest
{
    public class UserUseCaseTest
    {
        [Fact]
        public void AddUser()
        {
            var user = new User("User1", "user1@email.com", "12345678");
            var userRepositoryMock = new Mock<IUserWriteOnlyUseCase>();
            var userAddUseCase = new AddUserUseCase(userRepositoryMock.Object);
            userAddUseCase.Add(user);
            userRepositoryMock.Verify(x => x.Add(It.IsAny<User>()));
        }

        [Fact]
        public void UpdateUser()
        {
            var user = new User("User1", "user1@email.com", "12345678");
            var userRepositoryMock = new Mock<IUserWriteOnlyUseCase>();
            var userUpdateUseCase = new UpdateUserUseCase(userRepositoryMock.Object);
            userUpdateUseCase.Update(user);
            userRepositoryMock.Verify(x => x.Update(It.IsAny<User>()));
        }

        [Fact]
        public void RemoveUser()
        {
            var user = new User("User1", "user1@email.com", "12345678");
            var userRepositoryMock = new Mock<IUserWriteOnlyUseCase>();
            var userRemoveUseCase = new RemoveUserUseCase(userRepositoryMock.Object);
            userRemoveUseCase.Remove(user);
            userRepositoryMock.Verify(x => x.Remove(It.IsAny<User>()));
        }
        [Fact]
        public void GetAllUser()
        {
            var user = new User("User1", "user1@email.com", "12345678");
            var userRepositoryMock = new Mock<IUserReadOnlyUseCase>();
            var userGetAllUseCase = new GetAllUserUseCase(userRepositoryMock.Object);
            userGetAllUseCase.GetAll();
            userRepositoryMock.Verify(x => x.GetAll());
        }
        [Fact]
        public void GetByIdUser()
        {
            var user = new User("User1", "user1@email.com", "12345678");
            var userRepositoryMock = new Mock<IUserReadOnlyUseCase>();
            var userGetByIdUseCase = new GetByIdUserUseCase(userRepositoryMock.Object);
            userGetByIdUseCase.GetById(user.Id);
            userRepositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()));
        }

    }
}
