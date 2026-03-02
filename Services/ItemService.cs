using System;
using System.Linq.Expressions;
using BudgetAPI.Interfaces;
using BudgetAPI.Interfaces.Repository;
using BudgetAPI.Models;

namespace BudgetAPI.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _repository;

    public ItemService(IItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Item>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<Item?> GetByIdAsync(int id)
        => await _repository.GetByIdAsync(id);

    public async Task<Item?> CreateAsync(Item item)
    {
        await _repository.AddAsync(item);
        await _repository.SaveChangesAsync();

        return item;
    }

    public async Task<Item?> DeleteAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item is null)
            return null;

        await _repository.RemoveAsync(item);
        await _repository.SaveChangesAsync();

        return item;
    }

    public async Task<Item?> UpdateAsync(Item item)
    {
        var _item = await _repository.GetByIdAsync(item.Id);
        if (_item is null)
            return null;

        _item.Name = item.Name;
        _item.Price = item.Price;

        await _repository.UpdateAsync(_item);
        await _repository.SaveChangesAsync();

        return item;
    }
}
