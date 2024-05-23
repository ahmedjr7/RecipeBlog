using System;
using System.Collections.Generic;

namespace RecipeBlog.Models;

public partial class Giftcard
{
    public decimal Cardid { get; set; }

    public decimal? Userid { get; set; }

    public decimal? Balance { get; set; }

    public DateTime? Activationdate { get; set; }

    public DateTime? Expirationdate { get; set; }

    public virtual User? User { get; set; }
}
