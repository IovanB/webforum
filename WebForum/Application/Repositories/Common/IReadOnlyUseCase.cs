using System;
using System.Collections.Generic;

namespace Application.Repositories
{
    public interface IReadOnlyUseCase <TEntity>
    {
        IList<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}
