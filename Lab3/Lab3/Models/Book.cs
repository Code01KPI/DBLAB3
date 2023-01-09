﻿using System;
using System.Collections.Generic;

namespace Lab3;

public partial class Book
{
    public int BookId { get; set; }

    public int? DateOfPublication { get; set; }

    public int NumberOfPages { get; set; }

    public string Genre { get; set; } = null!;

    public int? BkLibraryId { get; set; }

    public string BookName { get; set; } = null!;

    public virtual ICollection<AuthorBook> AuthorBooks { get; } = new List<AuthorBook>();

    public virtual Library? BkLibrary { get; set; }
}
