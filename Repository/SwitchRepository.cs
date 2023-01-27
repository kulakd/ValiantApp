using Microsoft.EntityFrameworkCore;
using ValiantApp.Data;
using ValiantApp.Models;

namespace ValiantApp.Repository
{
    public class SwitchRepository : ISwitchRepository
    {
        private readonly AppDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SwitchRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor) 
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> GetByIdNoTracking(string id)
        {
            return await context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();

        }

        public async Task<User> GetUserById(string id)
        {
            return await context.Users.FindAsync(id);
        }

        public bool Save()
        {
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(User user)
        {
            context.Users.Update(user);
            return Save();
        }
    }
}
