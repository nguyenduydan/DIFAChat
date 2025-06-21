using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class conversation
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string CreatedUser { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public bool IsDeleted { get; set; }
}
