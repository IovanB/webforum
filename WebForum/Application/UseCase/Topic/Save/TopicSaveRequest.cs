namespace Application.UseCase.Topic.Save
{
    public class TopicSaveRequest
    {
        public Domain.Entities.Topic Topic { get; set; }

        public TopicSaveRequest(string name, Domain.Entities.Category category)
        {
            Topic = new Domain.Entities.Topic(name, category);
        }
    }
}
