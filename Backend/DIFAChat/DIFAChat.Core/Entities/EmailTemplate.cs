using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class emailtemplate
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Body { get; set; } = null!;

    public bool IsActived { get; set; }

    public bool IsDefault { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedUser { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string UpdatedUser { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }
}
