using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Services.Repositories
{
    public class CRUD : ICRUD
    {
        private readonly ApplicationDbContext _context;

        public CRUD(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create<T>(T objectForDb) where T : class
        {
            _context.Add<T>(objectForDb);
           await _context.SaveChangesAsync();
        }

        public Task Delete<T>(int entityId) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll<T>() where T : class
        {
            var result = await _context.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T> GetByID<T>(int entityId) where T : class
        {
            var entity = await _context.FindAsync<T>(entityId);
            return entity;
        }

        public async Task Update<T>(T objectToUpdate) where T : class
        {
           //_context.Entry(objectToUpdate).CurrentValues.SetValues(objectToUpdate);

            _context.Update<T>(objectToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
