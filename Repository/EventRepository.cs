using Microsoft.EntityFrameworkCore;
using ValiantApp.Data;
using ValiantApp.Models;

namespace ValiantApp.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext context;
        public EventRepository(AppDbContext context)
        {
            this.context = context;
        }

        public bool Add(Event events)
        {
            context.Add(events);
            return Save();
        }

        public bool Delete(Event events)
        {
            context.Remove(events);
            return Save();
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await context.Events.ToListAsync();
        }

        public async Task<Event?> GetByIdAsync(int id)
        {
            return await context.Events.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Event?> GetByIdAsyncNoTrack(int id)
        {
            return await context.Events.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public bool Save()
        {
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(Event events)
        {
            context.Update(events);
            return Save();
        }
    }
}