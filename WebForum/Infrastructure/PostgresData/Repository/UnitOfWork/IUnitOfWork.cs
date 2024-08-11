using Infrastructure.PostgresData.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.PostgresData.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Domain.Entities.Category> Categories { get; }
        IGenericRepository<Domain.Entities.Topic> Topics { get; }
        IGenericRepository<Domain.Entities.Post> Posts{ get; }
        IGenericRepository<Domain.Entities.Comment> Comments { get; }
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync();
        Task RollbackAsync();
    }
}
