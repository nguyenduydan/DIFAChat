using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class token
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string Token1 { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;

    public string AccountType { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime TokenExpired { get; set; }

    public DateTime RefreshExpired { get; set; }
}
