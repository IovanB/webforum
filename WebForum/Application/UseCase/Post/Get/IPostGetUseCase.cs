using Application.UseCase.Post.Save;
using System;

namespace Application.UseCase.Post.Get
{
    public interface IPostGetUseCase
    {
        void Execute(PostGetRequest request);

    }
}
