using InventoryMngSys.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryMngSys.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepo(AppDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<T> AddAsync(T model)
        {
            await _entity.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<T> DeleteAsync(T model)
        {
            try
            {
                _entity.Remove(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return model;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _entity.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" GenericRepo-GetAllAsync-Error : {ex.Message}");
                return Enumerable.Empty<T>();
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _entity.FindAsync(id);
            }
            catch (Exception ex) {

                return null;
            } 
        }

        public async Task<T> UpdateAsync(T model)
        {
            _entity.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> IsExists(int id)
        {
            var existingID = await GetByIdAsync(id);
            if (existingID != null) { 
                return true;
            }
            return false;
        }

    }
}
