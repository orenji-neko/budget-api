using System;
using System.Linq.Expressions;
using BudgetAPI.Data;
using BudgetAPI.Interfaces.Repository;
using BudgetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetAPI.Repositories;

public class ItemRepository : IItemRepository
{
  private readonly AppDbContext _context;

  public ItemRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task AddAsync(Item item)
  {
    await _context.Items.AddAsync(item);
  }

  public async Task<int> CountAsync()
  {
    var count = await _context.Items.CountAsync();
    return count;
  }

  public async Task<bool> ExistsAsync(Expression<Func<Item, bool>> predicate)
  {
    if (predicate == null)
      throw new ArgumentNullException(nameof(predicate));

    return await _context.Set<Item>().AnyAsync();
  }

  public Task<IReadOnlyList<Item>> FindAsync(Expression<Func<Item, bool>> predicate)
  {
    throw new NotImplementedException();
  }

  public Task<Item?> GetByIdAsync(int id)
  {
    throw new NotImplementedException();
  }

  public void Remove(Item item)
  {
    throw new NotImplementedException();
  }

  public Task<int> SaveChangesAsync()
  {
    throw new NotImplementedException();
  }

  public Task<IReadOnlyList<Item>> ToListAsync()
  {
    throw new NotImplementedException();
  }

  public void Update(Item item)
  {
    throw new NotImplementedException();
  }
}
