using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Services.Repositories
{
    public class JuegoRepository: IJuegoRepository
    {
        private readonly ApplicationDbContext _context;

        public JuegoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Juego>> GetAll(string juegoName, int GeneroId, int ConsolaId, int DesarrolladoraId, int ModoDeJuegoId)
        {
            var juegoQueryable = _context.Juegos.AsQueryable();
            if (!string.IsNullOrEmpty(juegoName))
            {
                juegoQueryable = juegoQueryable.Where(p => p.JuegoName.Contains(juegoName));
            }
            if (DesarrolladoraId != 0)
            {
                juegoQueryable = juegoQueryable.Where(p => p.Desarrolladora.DesarrolladorId == DesarrolladoraId);

            }
            if (GeneroId != 0)
            {
                juegoQueryable = juegoQueryable.Where(p => p.Generos
                                                .Select(g => g.GeneroId)
                                                .Contains(GeneroId));
            }
            if (ConsolaId != 0)
            {
                juegoQueryable = juegoQueryable.Where(p => p.JuegoConsola
                                                .Select(g => g.ConsolaId)
                                                .Contains(ConsolaId));
            }

            if (ModoDeJuegoId != 0)
            {
                juegoQueryable = juegoQueryable.Where(p => p.ModosDeJuegos
                                                .Select(g => g.ModosDeJuegoId)
                                                .Contains(ModoDeJuegoId));
            }

            var juegos = await juegoQueryable.OrderBy(j => j.JuegoName)
                                             .Include(j => j.Generos)
                                             .Include(j => j.Desarrolladora)
                                             .Include(j => j.Publicadora)
                                             .ToListAsync();
            return juegos;
        }

        public async Task<Juego> GetById(int juegoId) 
        {
            return await _context.Juegos
                    .Where(j => j.JuegoId == juegoId)
                    .Include(j => j.Generos.OrderByDescending(g => g.Nombre))
                    .Include(j => j.JuegoConsola)
                     .ThenInclude(jc => jc.Consola).ThenInclude(c => c.Marca)
                     .Include(j => j.Desarrolladora)
                     .Include(j => j.Publicadora).FirstOrDefaultAsync();
        }

        public async Task Create(Juego juego) 
        {
            _context.Juegos.Add(juego);
            await _context.SaveChangesAsync();
        }
    }
}
