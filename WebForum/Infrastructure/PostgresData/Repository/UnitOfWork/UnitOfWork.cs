using AutoMapper;
using Infrastructure.Context;
using Infrastructure.PostgresData.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.PostgresData.Repository.UnitOfWork
{
    public class UnitOfWork(ApplicationContext context, IMapper mapper) : IUnitOfWork
    {
        private readonly ApplicationContext _context = context;
        private readonly IMapper _mapper = mapper;
        private IDbContextTransaction _transaction;

        private IGenericRepository<Domain.Entities.Category> _category;
        private IGenericRepository<Domain.Entities.Topic> _topic;
        private IGenericRepository<Domain.Entities.Post> _post;
        private IGenericRepository<Domain.Entities.Comment> _comment;

        public IGenericRepository<Domain.Entities.Category> Categories => _category ??= new GenericRepository<Domain.Entities.Category, Data.Entity.Entities.Category>(_context, _mapper);
        public IGenericRepository<Domain.Entities.Topic> Topics => _topic ??= new GenericRepository<Domain.Entities.Topic, Data.Entity.Entities.Topic>(_context, _mapper);
        public IGenericRepository<Domain.Entities.Post> Posts => _post ??= new GenericRepository<Domain.Entities.Post, Data.Entity.Entities.Post>(_context, _mapper);
        public IGenericRepository<Domain.Entities.Comment> Comments => _comment ??= new GenericRepository<Domain.Entities.Comment, Data.Entity.Entities.Comment>(_context, _mapper);

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                if (_transaction != null)
                {
                    await _transaction.CommitAsync(cancellationToken);
                }
            }
            catch (System.Exception)
            {
                if (_transaction != null)
                {
                    await RollbackAsync();
                }
                throw;
            }
            finally
            {
                DisposeTransaction();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            DisposeTransaction();
        }


        private void DisposeTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
    }
}
