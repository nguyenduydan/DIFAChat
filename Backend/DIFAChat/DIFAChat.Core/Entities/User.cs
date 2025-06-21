using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class user
{
    public string Id { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public bool IsActivated { get; set; }

    public bool IsDeleted { get; set; }

    public string Avatar { get; set; } = null!;

    public int LoginFailedNumber { get; set; }

    public DateTime PasswordChangeDate { get; set; }

    public bool IsChangePassword { get; set; }

    public string ResetPasswordId { get; set; } = null!;

    public DateTime ResetPasswordExpired { get; set; }

    public string AuthenticatorKey { get; set; } = null!;

    public string CreatedUser { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string UpdatedUser { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }
}
