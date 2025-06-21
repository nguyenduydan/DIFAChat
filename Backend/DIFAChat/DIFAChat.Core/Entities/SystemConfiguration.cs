using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class systemconfiguration
{
    public string Id { get; set; } = null!;

    public string UserID { get; set; } = null!;

    public string SettingName { get; set; } = null!;

    public string SettingValue { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string UpdatedUser { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }

    public DateTime CreatedDate { get; set; }
}
