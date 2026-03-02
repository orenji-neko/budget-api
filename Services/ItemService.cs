using System;
using System.Linq.Expressions;
using BudgetAPI.Interfaces;
using BudgetAPI.Interfaces.Repository;
using BudgetAPI.Models;

namespace BudgetAPI.Services;

public class ItemService : IItemService
{
  public readonly IItemRepository _repository;

  public ItemService(IItemRepository repository)
  {
    _repository = repository;
  }

  public async Task<Item?> GetItemAsync(int id)
    => await _repository.GetByIdAsync(id);

  public async Task<IReadOnlyList<Item>> GetAllItemsAsync()
    => await _repository.ToListAsync();

  public async Task<IReadOnlyList<Item>> SearchItemsAsync(Expression<Func<Item, bool>> predicate)
    => await _repository.FindAsync(predicate);

  public async Task CreateItemAsync(Item item)
  {
    var _item = new Item
    {
      Name = item.Name,
      Price = item.Price,
      CreatedAt = DateTime.UtcNow
    };

    await _repository.AddAsync(_item);
    await _repository.SaveChangesAsync();
  }

  public async Task UpdateItemAsync(int id, Item item)
  {
    // check if item exists
    var _item = await _repository.GetByIdAsync(id) ??
      throw new KeyNotFoundException($"Item with id {id} not found.");

    _item.Name = item.Name;
    _item.Price = item.Price;

    _repository.Update(_item);
    await _repository.SaveChangesAsync();
  }

  public async Task DeleteItemAsync(int id)
  {
    var _item = await _repository.GetByIdAsync(id) ??
      throw new KeyNotFoundException($"Item with id {id} not found.");

    _repository.Remove(_item);
    await _repository.SaveChangesAsync();
  }
}
