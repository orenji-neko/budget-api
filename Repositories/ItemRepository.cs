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
    return await _context.Items.CountAsync();
  }

  public async Task<bool> ExistsAsync(Expression<Func<Item, bool>> predicate)
  {
    if (predicate == null)
      throw new ArgumentNullException(nameof(predicate));

    return await _context.Items.AnyAsync(predicate);
  }

  public async Task<IReadOnlyList<Item>> FindAsync(Expression<Func<Item, bool>> predicate)
  {
    if (predicate == null)
      throw new ArgumentNullException(nameof(predicate));

    return await _context.Items.Where(predicate).ToListAsync();
  }

  public async Task<Item?> GetByIdAsync(int id)
  {
    return await _context.Items.FindAsync(id);
  }

  public async Task<int> SaveChangesAsync()
  {
    return await _context.SaveChangesAsync();
  }

  public async Task<IReadOnlyList<Item>> ToListAsync()
  {
    return await _context.Items.ToListAsync();
  }

  public void Update(Item item)
  {
    _context.Items.Update(item);
  }

  public void Remove(Item item)
  {
    _context.Items.Remove(item);
  }
}