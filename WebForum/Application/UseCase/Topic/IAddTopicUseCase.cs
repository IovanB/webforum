namespace WebForum.Application.UseCase.Topic
{
    public interface IAddTopicUseCase
    {
        int Add(Domain.Entities.Topic topic);
    }
}
