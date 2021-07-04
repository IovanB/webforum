using Application.Repositories.Common;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCase.Post.Save.Handler
{
    public class SavePostHandler : Handler<PostRequest>
    {
        private readonly IPostWriteOnlyUseCase postWriteOnlyUseCase;
        private readonly IUserReadOnlyUseCase userReadOnlyUseCase;
        private readonly ITopicReadOnlyUseCase topicReadOnlyUseCase;

        public SavePostHandler(IPostWriteOnlyUseCase postWriteOnlyUseCase, IUserReadOnlyUseCase userReadOnlyUseCase, ITopicReadOnlyUseCase topicReadOnlyUseCase)
        {
            this.postWriteOnlyUseCase = postWriteOnlyUseCase;
            this.userReadOnlyUseCase = userReadOnlyUseCase;
            this.topicReadOnlyUseCase = topicReadOnlyUseCase;
        }
        public override void ProcessRequest(PostRequest request)
        {
            var user = userReadOnlyUseCase.GetById(request.UserId);
            var topic = topicReadOnlyUseCase.GetById(request.TopicId);
            var postRequest = new PostRequest(request.Title, request.Content, topic, user);
            var req = postWriteOnlyUseCase.Save(postRequest.Post);
            if (req == 0)
                throw new ArgumentException("Problem while adding Post");
            if (sucessor != null)
                sucessor.ProcessRequest(postRequest);
        }
    }
}
