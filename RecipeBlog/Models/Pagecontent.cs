using System;
using System.Collections.Generic;

namespace RecipeBlog.Models;

public partial class Pagecontent
{
    public decimal Pagecontentid { get; set; }

    public string? Pagename { get; set; }

    public string? Contentkey { get; set; }

    public string? Contentvalue { get; set; }
}
