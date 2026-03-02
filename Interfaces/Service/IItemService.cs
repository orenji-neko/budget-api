using System;
using System.Linq.Expressions;
using BudgetAPI.Models;

namespace BudgetAPI.Interfaces;

public interface IItemService
{
    Task<IEnumerable<Item>> GetAllAsync();
    Task<Item?> GetByIdAsync(int id);
    Task<Item?> CreateAsync(Item item);
    Task<Item?> UpdateAsync(Item item);
    Task<Item?> DeleteAsync(int id);
}
