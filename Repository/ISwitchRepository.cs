using ValiantApp.Models;

namespace ValiantApp.Data
{
    public interface ISwitchRepository
    {
        Task<User> GetUserById(string id);
        Task<User> GetByIdNoTracking(string id);
        bool Update(User user);
        bool Save();
    }
}
