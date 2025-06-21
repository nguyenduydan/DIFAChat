using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class participant
{
    public string Id { get; set; } = null!;

    public string ConversationId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string Type { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public bool IsDeleted { get; set; }
}
