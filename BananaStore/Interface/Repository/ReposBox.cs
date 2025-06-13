using BananaStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BananaStore.Interface.Repository
{
    public class ReposBox : IBox
    {
        private readonly BananaStoreDbContext _context;
        public ReposBox(BananaStoreDbContext context) => _context = context;
        public async Task<IEnumerable<Box>> List() => await _context.Boxes.ToListAsync();
        public async Task<IEnumerable<Box>> List_v2() => await _context.Boxes.Include(b => b.Bananas).ToListAsync();
        public async Task<IEnumerable<Box>> Get(Guid id) => await _context.Boxes.Where(b => b.Id == id).ToListAsync();
        public async Task Create(Box box)
        {
            _context.Boxes.Add(box);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Box box, Guid id)
        {
            var existingBox = await _context.Boxes.FindAsync(id);
            if (existingBox != null)
            {
                existingBox.HexColor = box.HexColor;
                existingBox.CreatedAt = box.CreatedAt;  
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            var box = await _context.Boxes.FindAsync(id);
            if (box != null)
            {
                _context.Boxes.Remove(box);
                await _context.SaveChangesAsync();
            }
        }
    }
}
