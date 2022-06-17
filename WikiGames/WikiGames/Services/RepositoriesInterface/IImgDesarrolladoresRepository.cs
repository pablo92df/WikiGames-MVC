using WikiGames.Models.Entities;

namespace WikiGames.Services.RepositoriesInterface
{
	public interface IImgDesarrolladoresRepository
	{
		Task Create(ImgDesarrolladores imgDesarrolladores);
		Task<ImgDesarrolladores> GetByPath(string imgPath);
	}
}
