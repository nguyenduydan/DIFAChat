using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DIFAChat.API;

public partial class DifaChatDbContext : DbContext
{
    public DifaChatDbContext(DbContextOptions<DifaChatDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<access> accesses { get; set; }

    public virtual DbSet<activity> activities { get; set; }

    public virtual DbSet<attachment> attachments { get; set; }

    public virtual DbSet<blocklist> blocklists { get; set; }

    public virtual DbSet<contact> contacts { get; set; }

    public virtual DbSet<conversation> conversations { get; set; }

    public virtual DbSet<deletedmessage> deletedmessages { get; set; }

    public virtual DbSet<device> devices { get; set; }

    public virtual DbSet<emailconfiguration> emailconfigurations { get; set; }

    public virtual DbSet<emailtemplate> emailtemplates { get; set; }

    public virtual DbSet<invitation> invitations { get; set; }

    public virtual DbSet<message> messages { get; set; }

    public virtual DbSet<participant> participants { get; set; }

    public virtual DbSet<report> reports { get; set; }

    public virtual DbSet<systemconfiguration> systemconfigurations { get; set; }

    public virtual DbSet<token> tokens { get; set; }

    public virtual DbSet<user> users { get; set; }

    public virtual DbSet<usercontact> usercontacts { get; set; }

    public virtual DbSet<userverification> userverifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<access>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("access")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.DevicesId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Token)
                .HasMaxLength(300)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.ActivitiveType)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Detail)
                .HasMaxLength(200)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Title)
                .HasMaxLength(45)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<attachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.FileData).HasColumnType("blob");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.FileType)
                .HasMaxLength(30)
                .HasDefaultValueSql("''");
            entity.Property(e => e.FileUrl)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.MessageId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
            entity.Property(e => e.ThumbUrl)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<blocklist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("blocklist")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.BlockUserId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("contact")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Phone)
                .HasMaxLength(14)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<conversation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("conversation")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(30)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<deletedmessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.MessageId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<device>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.DeviceToken)
                .HasMaxLength(300)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<emailconfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("emailconfiguration")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(30)
                .HasDefaultValueSql("''");
            entity.Property(e => e.EmailTemplateId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
            entity.Property(e => e.EmailTemplateKey)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedUser)
                .HasMaxLength(30)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<emailtemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("emailtemplate")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(30)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Subject)
                .HasMaxLength(250)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedUser)
                .HasMaxLength(30)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<invitation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UserReceiveId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UserRequestId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.ConversationId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Message1).HasColumnName("Message");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedUser)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<participant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.ConversationId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.ParticipantId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<systemconfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("systemconfiguration")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .HasDefaultValueSql("''");
            entity.Property(e => e.SettingName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedUser)
                .HasMaxLength(30)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UserID)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<token>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("token")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.AccountType)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.RefreshExpired)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(250)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Token1)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("Token");
            entity.Property(e => e.TokenExpired)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasDefaultValueSql("''");
            entity.Property(e => e.AuthenticatorKey)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Birthday)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedUser)
                .HasMaxLength(30)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PasswordChangeDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
            entity.Property(e => e.ResetPasswordExpired)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.ResetPasswordId)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedUser)
                .HasMaxLength(30)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<usercontact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("usercontact")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.ContactId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<userverification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("userverification")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasDefaultValueSql("''");
            entity.Property(e => e.VerificationCode)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
