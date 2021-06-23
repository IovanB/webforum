using Application.Repositories;
using Domain.Entities;

namespace Application.Repositories.Interfaces
{
    public interface ICommentWriteOnlyUseCase: IWriteOnlyUseCase<Comment>
    {
    }
}
