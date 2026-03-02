using BudgetAPI.Data;
using BudgetAPI.Interfaces;
using BudgetAPI.Interfaces.Repository;
using BudgetAPI.Repositories;
using BudgetAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddControllers();

// repositories
builder.Services.AddScoped<IItemRepository, ItemRepository>();

// services
builder.Services.AddScoped<IItemService, ItemService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
