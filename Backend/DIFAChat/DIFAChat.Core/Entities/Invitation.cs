using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class invitation
{
    public string Id { get; set; } = null!;

    public string UserRequestId { get; set; } = null!;

    public string UserReceiveId { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
