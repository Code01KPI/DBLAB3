using System;
using System.Collections.Generic;

namespace Lab3;

public partial class Reader
{
    public int Id { get; set; }

    public int LibraryId { get; set; }

    public int PersonId { get; set; }

    public string TakenBook { get; set; } = null!;

    public Reader() { }

    public Reader(int id, int libId, int perId, string takenBook)
    {
        Id = id;
        LibraryId = libId;
        PersonId = perId;
        TakenBook = takenBook;
    }

    public virtual Library Library { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
