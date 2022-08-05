using System;

namespace Application.UseCases.Topic.Save
{
    public class TopicSaveRequest
    {
        public Domain.Entities.Topic Topic { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public TopicSaveRequest(string name, Guid categoryId)
        {
            Topic = new Domain.Entities.Topic(Guid.NewGuid(),name, categoryId);
        }
        public TopicSaveRequest(Guid id, string name, Guid categoryId)
        {
            Topic = new Domain.Entities.Topic(id, name, categoryId);
        }
    }
}
