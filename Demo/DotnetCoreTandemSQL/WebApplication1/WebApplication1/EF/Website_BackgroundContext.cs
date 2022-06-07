using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.EF
{
    public partial class Website_BackgroundContext : DbContext
    {
        public Website_BackgroundContext()
        {
        }

        public Website_BackgroundContext(DbContextOptions<Website_BackgroundContext> options)
            : base(options)
        {
        }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=150.117.83.67;database=Website_Background;Trusted_Connection=False;user id=carl;password=1165;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContentHtml)
                    .HasColumnType("text")
                    .HasColumnName("content_html");

                entity.Property(e => e.ContentText)
                    .HasColumnType("text")
                    .HasColumnName("content_text");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(CONVERT([varchar],getdate(),(120)))");

                entity.Property(e => e.ImgUrl)
                    .HasColumnType("text")
                    .HasColumnName("img_url");

                entity.Property(e => e.Sort)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sort");

                entity.Property(e => e.Subtitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subtitle");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.Property(e => e.Test1).HasColumnName("test");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
