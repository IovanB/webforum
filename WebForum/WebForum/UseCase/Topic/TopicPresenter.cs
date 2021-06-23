using Application.Boundaries.Topic;
using System;
using System.Collections.Generic;

namespace WebForumApi.UseCase.Topic
{
    public class TopicPresenter : IOutputPort
    {
        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void NotFound(string message)
        {
            throw new NotImplementedException();
        }

        public void Standard(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Standard(Domain.Entities.Topic topic)
        {
            throw new NotImplementedException();
        }

        public void Standard(IList<Domain.Entities.Topic> topic)
        {
            throw new NotImplementedException();
        }
    }
}
