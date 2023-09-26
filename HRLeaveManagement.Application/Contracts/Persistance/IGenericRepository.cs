using HRLeaveManagement.Domain.common;

namespace HRLeaveManagement.Application.Contracts.Persistance
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAsync();
        Task<T> GetByidAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);               
      
    }

}