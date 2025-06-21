using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class contact
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime UpdateDate { get; set; }
}
