using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Services.Repositories
{
    public class MarcaRepository:IMarcaRepository
    {
        private readonly ApplicationDbContext _context;
        public MarcaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Marca>> GetAll() 
        {
            var marcas = await _context.Marcas.OrderBy(m => m.MarcaName).ToListAsync();
            return marcas;
        }
        public async Task<Marca> GetById(int id) 
        {
            var marca = await _context.Marcas.FirstOrDefaultAsync(m => m.MarcaId == id);
            return marca;
        }
        public async Task Delete(Marca marca) 
        {
            _context.Remove(marca);
            await _context.SaveChangesAsync();
        }
        public  async Task Create(Marca marca) 
        {
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();
        }
    }
}
