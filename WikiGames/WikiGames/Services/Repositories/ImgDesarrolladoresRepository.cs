using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Services.Repositories
{
	public class ImgDesarrolladoresRepository: IImgDesarrolladoresRepository
	{
		private readonly ApplicationDbContext _context;

		public ImgDesarrolladoresRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ImgDesarrolladores> GetByPath(string imgPath) 
		{
			return await _context.ImgDesarrolladores.Where(i => i.ImagePath == imgPath).FirstOrDefaultAsync();
		}

		public async Task<ImgDesarrolladores> GetById(int id)
		{
			return await _context.ImgDesarrolladores.Where(i => i.ImgDesarrolladoresId == id).FirstOrDefaultAsync();
		}
		public async Task Delete(ImgDesarrolladores imgDesarrollador) 
		{
			_context.ImgDesarrolladores.Remove(imgDesarrollador);
			await _context.SaveChangesAsync();	
		}
	}
}
