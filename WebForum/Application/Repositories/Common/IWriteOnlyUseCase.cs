using System;

namespace Application.Repositories
{
    public interface IWriteOnlyUseCase <TEntity>
    {
        int Add(TEntity entity);
        int Remove(Guid id);
        int Update(TEntity entity);
        int Save(TEntity entity);
    }
}
