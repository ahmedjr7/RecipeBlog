using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBlog.Models;

public partial class Recipe

{
    public enum RecipeStatus
    {
        Pending, // default status when a recipe is added
        Approved,
        Rejected
    }

    public decimal Recipeid { get; set; }

    public decimal? Userid { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Ingredients { get; set; }

    public string? Instructions { get; set; }

    public decimal? Categoryid { get; set; }

    public DateTime? Addedtime { get; set; }

    public string? Mainimage { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; }

    public decimal? Price { get; set; }

    public RecipeStatus Status { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Recipesale> Recipesales { get; set; } = new List<Recipesale>();

    public virtual User? User { get; set; }
}
