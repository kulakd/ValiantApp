using ValiantApp.Models;

namespace ValiantApp.Data
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetByIdAsync(int id);
        Task<Event?> GetByIdAsyncNoTrack(int id);
        bool Add(Event events);
        bool Update(Event events);
        bool Delete(Event events);
        bool Save();
    }
}
