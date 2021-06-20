
namespace Application.UseCase.User.Delete
{
    public interface IRemoveUserUseCase
    {
        int Remove(WebForum.Domain.Entities.User user);
    }
}
