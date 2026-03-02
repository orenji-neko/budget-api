using System;
using System.Linq.Expressions;
using BudgetAPI.Models;

namespace BudgetAPI.Interfaces.Repository;

public interface IItemRepository
{
    Task<Item?> GetByIdAsync(int id);
    Task<IReadOnlyList<Item>> GetAllAsync();
    Task<IReadOnlyList<Item>> FindAsync(Expression<Func<Item, bool>> predicate);

    Task<Item> AddAsync(Item item);
    Task<Item?> UpdateAsync(Item item);
    Task<Item?> RemoveAsync(Item item);

    Task<int> CountAsync();
    Task<int> SaveChangesAsync();
}
