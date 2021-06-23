namespace Application.UseCase.User.Save
{
    public class UserSaveRequest
    {
        public Domain.Entities.User User{ get; set; }
        public UserSaveRequest(string name, string email, string password)
        {
            User = new Domain.Entities.User(name, email, password);
        }
    }
}
