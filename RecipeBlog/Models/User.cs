using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBlog.Models;

public partial class User
{
    public decimal Userid { get; set; }
    [Required(ErrorMessage = "Enter the User Name")]
    public string? Username { get; set; }
    [EmailAddress]
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    public decimal? Roleid { get; set; }
    public string? Profileimage { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; }

    public virtual ICollection<Chef> Chefs { get; set; } = new List<Chef>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Giftcard> Giftcards { get; set; } = new List<Giftcard>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public virtual ICollection<Recipesale> Recipesales { get; set; } = new List<Recipesale>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Testimonial> Testimonials { get; set; } = new List<Testimonial>();
}
