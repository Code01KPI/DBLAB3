using System;
using System.Collections.Generic;

namespace ConsoleApp;

public partial class Reader
{
    public int Id { get; set; }

    public int LibraryId { get; set; }

    public int PersonId { get; set; }

    public string TakenBook { get; set; } = null!;

    public virtual Library Library { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
