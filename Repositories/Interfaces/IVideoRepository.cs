using Mobflix_backend.Models;

namespace Mobflix_backend.Repositories.Interfaces;

public interface IVideoRepository
{
    Task<Video> Save(Video video);
    Task<IEnumerable<Video>> GetAll();
    Task<Video?> GetById(int id);
    Task Delete(int id);
    Task Update(Video video);
}
