using InventoryMngSys.Models;

namespace InventoryMngSys.Repository
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T model);

        Task<T> UpdateAsync(T model);

        Task<T> DeleteAsync(T model);
    }
}
