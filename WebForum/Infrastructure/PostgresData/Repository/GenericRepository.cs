using AutoMapper;
using Infrastructure.Context;
using Infrastructure.PostgresData.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.PostgresData.Repository
{
    public class GenericRepository<TDomain, TInfrastructure> : IGenericRepository<TDomain>
        where TDomain : class
        where TInfrastructure : class
    {
        private readonly ApplicationContext _context;
        public readonly DbSet<TInfrastructure> _dbSet;
        private readonly IMapper _mapper;

        public GenericRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = _context.Set<TInfrastructure>(); 
        }
        public async Task Add(TDomain entity)
        {
            var infrastructureEntity = _mapper.Map<TInfrastructure>(entity);
            await _dbSet.AddAsync(infrastructureEntity); 
        }

        public void Delete(TDomain entity)
        {
            var infrastructureEntity = _mapper.Map<TInfrastructure>(entity);

            if (_context.Entry(infrastructureEntity).State == EntityState.Detached)
            {
                _dbSet.Attach(infrastructureEntity);  
            }    
           _dbSet.Remove(infrastructureEntity);   
        }

        public async Task<IEnumerable<TDomain>> GetAll()
        {
            var infrastructureEntities = await _dbSet.ToListAsync();

            var domainEntities = _mapper.Map<IEnumerable<TDomain>>(infrastructureEntities);

            return domainEntities;
        }

        public async Task<TDomain> GetById(int id)
        {
            var infrastructureEntities = await _dbSet.FindAsync(id);
            return  _mapper.Map<TDomain>(infrastructureEntities);   
        }

        public void Update(TDomain entity)
        {
            var infrastructureEntity = _mapper.Map<TInfrastructure>(entity);
            _dbSet.Attach(infrastructureEntity);
            _context.Entry(infrastructureEntity).State = EntityState.Modified;
        }
    }
}
