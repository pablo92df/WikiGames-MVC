using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Services.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly ApplicationDbContext _context;

        public GeneroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genero>> GetAll() 
        {
            var genero = await _context.Generos.OrderBy(g => g.Nombre).ToListAsync();
            return genero;
        }

        public async Task<Genero> GetById(int id) 
        {
            var genero = await _context.Generos.Where(g=>g.GeneroId==id).FirstOrDefaultAsync();

            return genero;
        }
        public async Task Update(Genero genero) 
        {
            _context.Generos.Update(genero);
            await _context.SaveChangesAsync();

        }
        public async Task Create(Genero genero) 
        {
            _context.Generos.Add(genero);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int generoId) 
        {
            var genero = await GetById(generoId); 
            _context.Generos.Remove(genero);
            await _context.SaveChangesAsync();
        }
    }
}
