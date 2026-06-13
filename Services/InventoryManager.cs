using InventoryService.Models;
using InventoryService.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryService.Services
{
    public interface IInventoryManager
    {
        Task<IEnumerable<InventoryItem>> GetAllAsync();
        Task<InventoryItem?> GetByProductIdAsync(int productId);
        Task<InventoryItem> CreateAsync(InventoryItem item);
        Task<bool> DecreaseInventoryAsync(int productId, int quantity);
    }

    public class InventoryManager : IInventoryManager
    {
        private readonly IInventoryRepository _repository;

        public InventoryManager(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InventoryItem>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<InventoryItem?> GetByProductIdAsync(int productId) => await _repository.GetByProductIdAsync(productId);

        public async Task<InventoryItem> CreateAsync(InventoryItem item) => await _repository.AddAsync(item);

        public async Task<bool> DecreaseInventoryAsync(int productId, int quantity)
        {
            var item = await _repository.GetByProductIdAsync(productId);
            if (item == null || item.Quantidade < quantity)
            {
                return false;
            }

            item.Quantidade -= quantity;
            await _repository.UpdateAsync(item);
            return true;
        }
    }
}