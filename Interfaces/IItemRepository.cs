using System;
using System.Linq.Expressions;
using BudgetAPI.Models;

namespace BudgetAPI.Interfaces.Repository;

public interface IItemRepository
{
  // READ
  Task<Item?> GetByIdAsync(int id);
  Task<IReadOnlyList<Item>> ToListAsync();
  Task<IReadOnlyList<Item>> FindAsync(Expression<Func<Item, bool>> predicate);

  // CREATE
  Task AddAsync(Item item);

  // UPDATE
  void Update(Item item);

  // DELETE
  void Remove(Item item);

  // MISC
  Task<int> CountAsync();
  Task<bool> ExistsAsync(Expression<Func<Item, bool>> predicate);
  Task<int> SaveChangesAsync();
}
