using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class DeletedMessage
{
    public string Id { get; set; } = null!;

    public string MessageId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdateDate { get; set; }
}
