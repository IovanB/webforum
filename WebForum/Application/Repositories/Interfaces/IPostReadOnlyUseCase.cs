using Application.Repositories;
using Domain.Entities;

namespace Application.Repositories.Interfaces
{
    public interface IPostReadOnlyUseCase : IReadOnlyUseCase<Post>
    {
    }
}
