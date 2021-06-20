namespace Application.UseCase.Topic.Delete
{
    public interface IRemoveTopicUseCase
    {
        int Remove(WebForum.Domain.Entities.Topic topic);
    }
}
