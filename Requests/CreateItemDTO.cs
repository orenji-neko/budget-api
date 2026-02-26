using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetAPI.Requests;

public class CreateItemDTO
{
  [Required]
  public string Name { get; set; } = string.Empty;

  [Required]
  public decimal Price { get; set; }
}
