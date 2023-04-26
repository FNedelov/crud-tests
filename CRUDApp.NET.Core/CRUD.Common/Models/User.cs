using System;
using System.Collections.Generic;

namespace CRUD.Common.Models;

public partial class User
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public bool Status { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Role Role { get; set; } = null!;
}
