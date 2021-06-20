namespace WebForum.Application.UseCase.User
{
    public interface IGetByNameUser
    {
        Domain.Entities.User GetByName(string name, string password);
    }
}
