using System;
using System.Collections.Generic;

namespace ConsoleApp;

public partial class Library
{
    public int Id { get; set; }

    public DateOnly GivingTime { get; set; }

    public DateOnly ReturnTime { get; set; }

    public DateOnly ActualReturnTime { get; set; }

    public virtual ICollection<Book> Books { get; } = new List<Book>();

    public virtual ICollection<Reader> Readers { get; } = new List<Reader>();
}
