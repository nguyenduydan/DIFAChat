using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class Access
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string DevicesId { get; set; } = null!;

    public string Token { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
