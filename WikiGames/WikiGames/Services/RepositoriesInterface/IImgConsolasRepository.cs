using WikiGames.Models.Entities;

namespace WikiGames.Services.RepositoriesInterface
{
    public interface IImgConsolasRepository
    {
        Task<ImgConsolas> GetById(int id);
        Task<ImgConsolas> GetByPath(string imgPath);
    }
}
