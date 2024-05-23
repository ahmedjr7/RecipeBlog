using System;
using System.Collections.Generic;

namespace RecipeBlog.Models;

public partial class Testimonial
{
    public decimal Testimonialid { get; set; }

    public decimal? Userid { get; set; }

    public string? Testimonialcontent { get; set; }

    public virtual User? User { get; set; }
}
