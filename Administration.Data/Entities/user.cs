using System;
using System.Collections.Generic;

namespace Administration.Data.Entities;

public partial class user
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string FatherId { get; set; } = null!;

    public string? FatherName { get; set; }

    public string? FamilyName { get; set; }

    public DateOnly DOB { get; set; }

    public string Address { get; set; } = null!;

    public string? MotherName { get; set; }

    public string? BloodGroup { get; set; }

    public string ContactNumber { get; set; } = null!;

    public bool IsAlive { get; set; }

    public bool IsMarried { get; set; }

    public bool IsDismissed { get; set; }

    public string? AadhaarId { get; set; }

    public string? PhotoPath { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
