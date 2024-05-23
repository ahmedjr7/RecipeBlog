using System;
using System.Collections.Generic;

namespace RecipeBlog.Models;

public partial class Feedback
{
    public decimal Feedbackid { get; set; }

    public decimal? Recipeid { get; set; }

    public decimal? Userid { get; set; }

    public string? Usercomment { get; set; }

    public DateTime? Postedat { get; set; }

    public virtual Recipe? Recipe { get; set; }

    public virtual User? User { get; set; }
}
