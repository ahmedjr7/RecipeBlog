using System;
using System.Collections.Generic;

namespace RecipeBlog.Models;

public partial class Chef
{
    public decimal Chefid { get; set; }

    public decimal? Userid { get; set; }

    public string? Subscriptiontype { get; set; }

    public DateTime? Subscriptionstartdate { get; set; }

    public DateTime? Subscriptionenddate { get; set; }

    public virtual User? User { get; set; }
}
