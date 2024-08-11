using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public interface ICommonUseCase<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task DeleteEntity(int id);
        Task UpdateEntity(T entity);
        Task Insert(T entity);
    }
}
