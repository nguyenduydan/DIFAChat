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

    public virtual DbSet<Access> Accesses { get; set; }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Blocklist> Blocklists { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Conversation> Conversations { get; set; }

    public virtual DbSet<DeletedMessage> DeletedMessages { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<EmailConfiguration> EmailConfigurations { get; set; }

    public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }

    public virtual DbSet<Invitation> Invitations { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<SystemConfiguration> SystemConfigurations { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserContact> UserContacts { get; set; }

    public virtual DbSet<UserVerification> UserVerifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Access>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("Access")
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

        modelBuilder.Entity<Activity>(entity =>
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

        modelBuilder.Entity<Attachment>(entity =>
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

        modelBuilder.Entity<Blocklist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("Blocklist")
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

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("Contact")
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

        modelBuilder.Entity<Conversation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("Conversation")
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

        modelBuilder.Entity<DeletedMessage>(entity =>
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

        modelBuilder.Entity<Device>(entity =>
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

        modelBuilder.Entity<EmailConfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("EmailConfiguration")
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

        modelBuilder.Entity<EmailTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("EmailTemplate")
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

        modelBuilder.Entity<Invitation>(entity =>
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

        modelBuilder.Entity<Message>(entity =>
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

        modelBuilder.Entity<Participant>(entity =>
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

        modelBuilder.Entity<Report>(entity =>
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

        modelBuilder.Entity<SystemConfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("SystemConfiguration")
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

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("Token")
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

        modelBuilder.Entity<User>(entity =>
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

        modelBuilder.Entity<UserContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("UserContact")
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

        modelBuilder.Entity<UserVerification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("UserVerification")
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
