using System;
using System.Collections.Generic;

namespace Lab3;

public partial class Library
{
    public int Id { get; set; }

    public DateOnly GivingTime { get; set; }

    public DateOnly ReturnTime { get; set; }

    public DateOnly ActualReturnTime { get; set; }

    public Library () { }

    public Library (int id, DateOnly givingTime, DateOnly returnTime, DateOnly actualReturnTime)
    {
        Id = id;
        GivingTime = givingTime;
        ReturnTime = returnTime;
        ActualReturnTime = actualReturnTime;
    }

    public virtual ICollection<Book> Books { get; } = new List<Book>();

    public virtual ICollection<Reader> Readers { get; } = new List<Reader>();
}
