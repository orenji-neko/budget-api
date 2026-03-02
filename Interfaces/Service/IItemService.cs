using System;
using System.Linq.Expressions;
using BudgetAPI.Models;

namespace BudgetAPI.Interfaces;

public interface IItemService
{
  Task<Item?> GetItemAsync(int id);
  Task<IReadOnlyList<Item>> GetAllItemsAsync();
  Task<IReadOnlyList<Item>> SearchItemsAsync(Expression<Func<Item, bool>> predicate);

  Task CreateItemAsync(Item item);
  Task UpdateItemAsync(int id, Item item);
  Task DeleteItemAsync(int id);
}
