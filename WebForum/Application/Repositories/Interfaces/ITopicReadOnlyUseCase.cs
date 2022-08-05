using Application.Repositories;
using Domain.Entities;

namespace Application.Repositories.Interfaces
{
    public interface ITopicReadOnlyUseCase : IReadOnlyUseCase<Topic>{}
}
