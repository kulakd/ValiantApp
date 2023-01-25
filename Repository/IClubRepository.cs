using ValiantApp.Models;

namespace ValiantApp.Data
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAll();
        Task<Club?> GetByIdAsync(int id);
        Task<Club?> GetByIdAsyncNoTrack(int id);

        bool Add(Club club);
        bool Update(Club club);
        bool Delete(Club club);
        bool Save();
    }
}
