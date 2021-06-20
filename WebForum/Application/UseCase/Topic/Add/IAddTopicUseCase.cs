namespace Application.UseCase.Topic.Add
{
    public interface IAddTopicUseCase
    {
        int Add(WebForum.Domain.Entities.Topic topic);
    }
}
