using BananaStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BananaStore.Interface.Repository
{
    public class ReposBanana : IBanana
    {
        private readonly BananaStoreDbContext _context;
        public ReposBanana(BananaStoreDbContext context) => _context = context;
        public async Task<IEnumerable<Banana>> List() => await _context.Bananas.ToListAsync();
        public async Task<IEnumerable<Banana>> Get(Guid id) => await _context.Bananas.Where(b => b.Id == id).ToListAsync();
        public async Task Create(Banana banana)
        {
            _context.Bananas.Add(banana);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Banana banana, Guid id)
        {
            var existingBanana = await _context.Bananas.FindAsync(id);
            if (existingBanana != null)
            {
                existingBanana.Description = banana.Description;
                existingBanana.CreatedAt = banana.CreatedAt;
                existingBanana.Box_ID = banana.Box_ID;
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            var banana = await _context.Bananas.FindAsync(id);
            if (banana != null)
            {
                _context.Bananas.Remove(banana);
                await _context.SaveChangesAsync();
            }
        }
    }
}
