namespace Application.UseCase.User.Save
{
    public class UserSaveRequest
    {
        public WebForum.Domain.Entities.User User{ get; set; }
        public UserSaveRequest(string name, string email, string password)
        {
            User = new WebForum.Domain.Entities.User(name, email, password);
        }
    }
}
