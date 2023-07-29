using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Member
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? Age { get; set; }
}
