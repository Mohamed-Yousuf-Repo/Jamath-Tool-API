using System;
using System.Collections.Generic;

namespace Administration.Data.Entities;

public partial class role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<auth> auths { get; set; } = new List<auth>();
}
