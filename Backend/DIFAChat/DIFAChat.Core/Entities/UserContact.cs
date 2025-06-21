using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class usercontact
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string ContactId { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public bool IsDeleted { get; set; }
}
