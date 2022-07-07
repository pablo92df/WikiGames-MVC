using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Services.Repositories
{
    public class ConsolaRepository:IConsolaRepository
    {
        private readonly ApplicationDbContext _context;
        public ConsolaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Consola> GetConsolaById(int id) 
        {
            return await _context.Consolas.Where(x => x.ConsolaId == id).Include(x => x.imgConsolas).Include(x => x.Marca).FirstOrDefaultAsync();
        }
    }
}
