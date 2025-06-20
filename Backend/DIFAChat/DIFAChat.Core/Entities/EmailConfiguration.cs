using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class EmailConfiguration
{
    public string Id { get; set; } = null!;

    public string EmailTemplateId { get; set; } = null!;

    public string EmailTemplateKey { get; set; } = null!;

    public bool IsSettingDefault { get; set; }

    public string CreatedUser { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string UpdatedUser { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
