using System;

namespace WebForum.Application.Repositories
{
    public interface IWriteOnlyUseCase <TEntity>
    {
        int Add(TEntity entity);
        int Remove(Guid id);
        int Update(Guid id);
    }
}
