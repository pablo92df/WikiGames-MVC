using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Services.Repositories
{
    public class ImgConsolaRepository : IImgConsolasRepository
	{
		private readonly ApplicationDbContext _context;

		public ImgConsolaRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ImgConsolas> GetByPath(string imgPath)
		{
			return await _context.ImgConsolas.Where(i => i.ImagePath == imgPath).FirstOrDefaultAsync();
		}

		public async Task<ImgConsolas> GetById(int id)
		{
			return await _context.ImgConsolas.Where(i => i.ImgConsolasId == id).FirstOrDefaultAsync();
		}
		public async Task Delete(ImgConsolas imgConsol)
		{
			_context.ImgConsolas.Remove(imgConsol);
			await _context.SaveChangesAsync();
		}
	}
}
