using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Services.Repositories
{
    public class PublicadoraRepository : IPublicadoraRepository
    {
        private readonly ApplicationDbContext _context;
        public PublicadoraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publicadora>> GetAll()
        {
            return await _context.Publicadoras.OrderBy(p => p.PublicadoraNombre).ToListAsync();
        }
       
    }
}
