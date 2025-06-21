using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class blocklist
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string BlockUserId { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
