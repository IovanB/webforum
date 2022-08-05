using Application.UseCases.Post.Save;
using System;

namespace Application.UseCases.Post.Get
{
    public interface IPostGetUseCase
    {
        void Execute(PostGetRequest request);

    }
}
