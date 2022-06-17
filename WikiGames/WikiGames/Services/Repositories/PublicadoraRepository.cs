using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;

namespace WikiGames.Services.Repositories
{
    public class PublicadoraRepository
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

        public async Task<Publicadora> GetById(int publicadoraId)
        {
            return await _context.Publicadoras.Where(p => p.PublicadoraId == publicadoraId).FirstOrDefaultAsync();

        }

        public async Task Create(Publicadora publicadora)
        {
            _context.Publicadoras.Add(publicadora);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Publicadora publicadora) 
        {
            _context.Remove(publicadora);
            await _context.SaveChangesAsync();
        }
    }
}
