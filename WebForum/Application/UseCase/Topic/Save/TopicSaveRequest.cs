using System;

namespace Application.UseCase.Topic.Save
{
    public class TopicSaveRequest
    {
        public Domain.Entities.Topic Topic { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public TopicSaveRequest(string name, Domain.Entities.Category category)
        {
            Topic = new Domain.Entities.Topic(name, category);
        }
        public TopicSaveRequest(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
