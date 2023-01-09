﻿using System;
using System.Collections.Generic;

namespace Lab3;

public partial class Person
{
    public int PersonId { get; set; }

    public string FullName { get; set; } = null!;

    public bool IsHaveTicket { get; set; }

    public virtual ICollection<Reader> Readers { get; } = new List<Reader>();
}