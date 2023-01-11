using System;
using System.Collections.Generic;

namespace ConsoleApp;

public partial class Author
{
    public int AuthorId { get; set; }

    public string FullName { get; set; } = null!;

    public string CountryOfOrigin { get; set; } = null!;

    public virtual ICollection<AuthorBook> AuthorBooks { get; } = new List<AuthorBook>();
}
