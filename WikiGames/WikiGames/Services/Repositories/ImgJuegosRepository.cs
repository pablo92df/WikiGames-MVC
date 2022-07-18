using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Services.Repositories
{
    public class ImgJuegosRepository:IImgJuegoRepository
    {
		private readonly ApplicationDbContext _context;

		public ImgJuegosRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ImgJuegos> GetByPath(string imgPath)
		{
			return await _context.ImgJuegos.Where(i => i.ImagePath == imgPath).FirstOrDefaultAsync();
		}

		public async Task<ImgJuegos> GetById(int id)
		{
			return await _context.ImgJuegos.Where(i => i.ImgJuegosId == id).FirstOrDefaultAsync();
		}
		public async Task Delete(ImgJuegos imgJuegos)
		{
			_context.ImgJuegos.Remove(imgJuegos);
			await _context.SaveChangesAsync();
		}
	}
}
