using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class activity
{
    public string Id { get; set; } = null!;

    public string ActivitiveType { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
