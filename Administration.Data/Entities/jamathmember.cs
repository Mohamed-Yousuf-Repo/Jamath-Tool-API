using System;
using System.Collections.Generic;

namespace Administration.Data.Entities;

public partial class jamathmember
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public int RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual role Role { get; set; } = null!;

    public virtual user User { get; set; } = null!;
}
