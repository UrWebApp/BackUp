using Microsoft.EntityFrameworkCore;
using Jose;
using System.Text;
using System.Dynamic;

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
            // 製作密鑰
            // 隨便給值通常會這樣給
            dynamic payload = new ExpandoObject();
            payload.BuId = "育愷";
            payload.UserId = "育愷";
            payload.UserName = "育愷";
            payload.ConnectionString = "Server=;database=;Trusted_Connection=False;user id=;password=;";
            payload.CreateTime = DateTime.UtcNow;
            payload.ExpTime = DateTime.UtcNow.AddMinutes(120);

            var Secret = ""; // 四碼：提示：我們家門牌號碼 MJ116
            // 加密
            string JwtToken = Jose.JWT.Encode(payload, Encoding.UTF8.GetBytes(Secret), JwsAlgorithm.HS256);

            JwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJCdUlkIjoi6IKy5oS3IiwiVXNlcklkIjoi6IKy5oS3IiwiVXNlck5hbWUiOiLogrLmhLciLCJDb25uZWN0aW9uU3RyaW5nIjoiU2VydmVyPTE1MC4xMTcuODMuNjc7ZGF0YWJhc2U9V2Vic2l0ZV9CYWNrZ3JvdW5kO1RydXN0ZWRfQ29ubmVjdGlvbj1GYWxzZTt1c2VyIGlkPWNhcmw7cGFzc3dvcmQ9MTE2NTsiLCJDcmVhdGVUaW1lIjoiMjAyMi0wNi0wN1QwNzoyMTozNS41MjQxNzI2WiIsIkV4cFRpbWUiOiIyMDIyLTA2LTA3VDA5OjIxOjM1LjUzMDYyNzFaIn0.hvGSmV0LjTqPO7bPLMnr_0syHA8J-8vrFLoKC7fziLs";

            // 解密
            var JwtObject = Jose.JWT.Decode<dynamic>(JwtToken, Encoding.UTF8.GetBytes(Secret), JwsAlgorithm.HS256);

            string ConnectionString = "";

            // 不一定要用字典來裝，因為我懶上面用動態宣告不是用 class
            foreach (var Property in (IDictionary<string, object>)JwtObject)
            {
                if (Property.Key == "ConnectionString")
                {
                    ConnectionString = Property.Value.ToString();
                }
            }

            // 連線
            optionsBuilder.UseSqlServer(ConnectionString);

            // ------------------------------------------------------------

            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            // optionsBuilder.UseSqlServer(ConnectionString);
            //}
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
