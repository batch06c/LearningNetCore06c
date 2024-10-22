using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Session.Models;

public partial class UserTbl
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }
    [DataType(DataType.Password)]
    public int? UserPassword { get; set; }

    public string? Gender { get; set; }
}
