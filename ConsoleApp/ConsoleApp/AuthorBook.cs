using System;
using System.Collections.Generic;

namespace ConsoleApp;

public partial class AuthorBook
{
    public int AuthorBookId { get; set; }

    public int BookFk { get; set; }

    public int AuthorFk { get; set; }

    public virtual Author AuthorFkNavigation { get; set; } = null!;

    public virtual Book BookFkNavigation { get; set; } = null!;
}
