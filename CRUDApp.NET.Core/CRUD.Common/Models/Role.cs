using System;
using System.Collections.Generic;

namespace CRUD.Common.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Definition { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public bool Status { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
