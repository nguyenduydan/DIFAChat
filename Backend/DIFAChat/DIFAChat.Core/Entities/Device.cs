using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class Device
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string DeviceToken { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
