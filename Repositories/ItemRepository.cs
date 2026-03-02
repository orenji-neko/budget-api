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

    public async Task<int> CountAsync()
        => await _context.Items.CountAsync();

    public async Task<IReadOnlyList<Item>> FindAsync(Expression<Func<Item, bool>> predicate)
        => await _context.Items.Where(predicate).ToListAsync();

    public async Task<IReadOnlyList<Item>> GetAllAsync()
        => await _context.Items.AsNoTracking().ToListAsync();

    public async Task<Item?> GetByIdAsync(int id)
        => await _context.Items.FindAsync(id);

    public async Task<Item> AddAsync(Item item)
    {
        await _context.Items.AddAsync(item);
        return item;
    }

    public async Task<Item?> UpdateAsync(Item item)
    {
        var exists = await _context.Items.AnyAsync(i => i.Id == item.Id);
        if (!exists)
            return null;

        _context.Items.Update(item);
        return item;
    }

    public async Task<Item?> RemoveAsync(Item item)
    {
        var exists = await _context.Items.AnyAsync(i => i.Id == item.Id);
        if (!exists)
            return null;

        _context.Items.Remove(item);
        return item;
    }

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
}