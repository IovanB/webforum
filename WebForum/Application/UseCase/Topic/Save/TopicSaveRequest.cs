namespace Application.UseCase.Topic.Save
{
    public class TopicSaveRequest
    {
        public WebForum.Domain.Entities.Topic Topic { get; set; }

        public TopicSaveRequest(string name, WebForum.Domain.Entities.Category category)
        {
            Topic = new WebForum.Domain.Entities.Topic(name, category);
        }
    }
}
