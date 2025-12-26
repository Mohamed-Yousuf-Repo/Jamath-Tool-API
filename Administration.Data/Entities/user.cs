using System;
using System.Collections.Generic;

namespace Administration.Data.Entities;

public partial class user
{
    public Guid Id { get; set; }

    public ulong ProfileNumber { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public Guid FatherId { get; set; }

    public string FamilyName { get; set; } = null!;

    public DateOnly DOB { get; set; }

    public string MotherName { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string? Email { get; set; }

    public string BloodGroup { get; set; } = null!;

    public bool? IsAlive { get; set; }

    public bool IsMarried { get; set; }

    public bool IsDismissed { get; set; }

    public string? AadhaarId { get; set; }

    public string PhotoPath { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<jamathmember> jamathmembers { get; set; } = new List<jamathmember>();
}
