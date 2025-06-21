using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class message
{
    public string Id { get; set; } = null!;

    public string ConversationId { get; set; } = null!;

    public string Message1 { get; set; } = null!;

    public string CreatedUser { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string UpdatedUser { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
