using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class Report
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string ParticipantId { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string Status { get; set; } = null!;
}
