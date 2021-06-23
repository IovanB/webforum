using Application.Repositories.Common;
using System;

namespace Application.UseCase.Topic.Save.Handler
{
    public class ValidateSaveRequest : Handler<TopicSaveRequest>
    {
        public override void ProcessRequest(TopicSaveRequest request)
        {
            if (!request.Topic.IsValid)
                throw new ArgumentException("Not a valid Topic");
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
