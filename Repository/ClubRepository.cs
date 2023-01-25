using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ValiantApp.Data;
using ValiantApp.Models;

namespace ValiantApp.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly AppDbContext context;

        public ClubRepository(AppDbContext context)
        {
            this.context = context;
        }

        public bool Add(Club club)
        {
            context.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await context.Groups.ToListAsync();
        }

        public async Task<Club?> GetByIdAsync(int id)
        {
            return await context.Groups.Include(i => i.Address).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Club?> GetByIdAsyncNoTrack(int id)
        {
            return await context.Groups.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public bool Save()
        {
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(Club club)
        {
            context.Update(club);
            return Save();
        }
    }
}
