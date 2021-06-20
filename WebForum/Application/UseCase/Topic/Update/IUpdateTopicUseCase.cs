namespace Application.UseCase.Topic.Update
{
    public interface IUpdateTopicUseCase
    {
        int Update(WebForum.Domain.Entities.Topic topic);
    }
}
