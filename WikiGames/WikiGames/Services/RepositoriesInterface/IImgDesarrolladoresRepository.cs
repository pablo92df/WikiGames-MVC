using WikiGames.Models.Entities;

namespace WikiGames.Services.RepositoriesInterface
{
	public interface IImgDesarrolladoresRepository
	{
        Task<ImgDesarrolladores> GetById(int id);

        //	Task Create(ImgDesarrolladores imgDesarrolladores);
        Task<ImgDesarrolladores> GetByPath(string imgPath);
	}
}
