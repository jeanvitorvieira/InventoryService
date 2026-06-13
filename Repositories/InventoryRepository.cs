using InventoryService.Data;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryService.Repositories
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<InventoryItem>> GetAllAsync();
        Task<InventoryItem?> GetByProductIdAsync(int productId);
        Task<InventoryItem> AddAsync(InventoryItem item);
        Task UpdateAsync(InventoryItem item);
    }

    public class InventoryRepository : IInventoryRepository
    {
        private readonly InventoryDbContext _context;

        public InventoryRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InventoryItem>> GetAllAsync()
        {
            return await _context.InventoryItems.ToListAsync();
        }

        public async Task<InventoryItem?> GetByProductIdAsync(int productId)
        {
            return await _context.InventoryItems.FirstOrDefaultAsync(i => i.ProductId == productId);
        }

        public async Task<InventoryItem> AddAsync(InventoryItem item)
        {
            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(InventoryItem item)
        {
            _context.InventoryItems.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}