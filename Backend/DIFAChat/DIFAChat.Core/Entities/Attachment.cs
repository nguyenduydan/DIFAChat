using System;
using System.Collections.Generic;

namespace DIFAChat.API;

public partial class Attachment
{
    public string Id { get; set; } = null!;

    public string MessageId { get; set; } = null!;

    public string ThumbUrl { get; set; } = null!;

    public string FileUrl { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public byte[] FileData { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public bool IsDeleted { get; set; }
}
