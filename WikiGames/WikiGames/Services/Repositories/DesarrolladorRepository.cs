using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Services.Repositories
{
    public class DesarrolladorRepository : IDesarrolladorRepository
    {
        private readonly ApplicationDbContext _context;
        public DesarrolladorRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<Desarrollador>> GetAll(string desarrolladorName) 
        {
            var desarrolladorQuery = _context.Desarrolladores.AsQueryable();
            if (!string.IsNullOrEmpty(desarrolladorName))
            {
                desarrolladorQuery = desarrolladorQuery.Where(d => d.DesarrolladorName.Contains(desarrolladorName));
            }
            return  await desarrolladorQuery.OrderBy(d => d.DesarrolladorName).Include(d=>d.ImgDesarrolladores).ToListAsync();
           
        }

        public async Task<Desarrollador> GetById(int desarrolladorId) 
        {
            return await _context.Desarrolladores.Where(d => d.DesarrolladorId == desarrolladorId).Include(d =>d.ImgDesarrolladores).FirstOrDefaultAsync();
        }

        public async Task<Desarrollador> GetAllInfo(int desarrolladorId) 
        {
            return await _context.Desarrolladores.Where(d => d.DesarrolladorId == desarrolladorId).Include(d =>d.ImgDesarrolladores).Include(d=>d.Juegos).FirstOrDefaultAsync();

        }

        //public async Task Edit(Desarrollador desarrollador)
        //{
        //    _context.Desarrolladores.Update(desarrollador);
        //    await _context.SaveChangesAsync();
        //}
        //public async Task Delete(int desarrolladorId)
        //{
        //    var desarrollador = await GetById(desarrolladorId);
        //    _context.Desarrolladores.Remove(desarrollador);
        //    await _context.SaveChangesAsync();
        //}
    }
}
