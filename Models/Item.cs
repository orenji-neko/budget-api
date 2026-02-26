using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetAPI.Models;

public class Item
{
  [Key]
  public int Id { get; set; }

  [Required]
  public string Name { get; set; } = string.Empty;

  [Required]
  public decimal Price { get; set; }

  public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
