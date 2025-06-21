using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class userverification
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string VerificationCode { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
