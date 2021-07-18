using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RepositoryLayer
{
    public partial class gamebookdbContext : DbContext
    {
        public gamebookdbContext()
        {
        }

        public gamebookdbContext(DbContextOptions<gamebookdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<PlayHistory> PlayHistories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.HasKey(e => new { e.User1Id, e.User2Id })
                    .HasName("PK__friend__AAA434A6A6D38D00");

                entity.ToTable("friend");

                entity.Property(e => e.User1Id).HasColumnName("user1_id");

                entity.Property(e => e.User2Id).HasColumnName("user2_id");

                entity.HasOne(d => d.User1)
                    .WithMany(p => p.FriendUser1s)
                    .HasForeignKey(d => d.User1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__friend__user1_id__5DCAEF64");

                entity.HasOne(d => d.User2)
                    .WithMany(p => p.FriendUser2s)
                    .HasForeignKey(d => d.User2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__friend__user2_id__5EBF139D");
            });

            modelBuilder.Entity<PlayHistory>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GameId })
                    .HasName("PK__play_his__564026F3D11D6314");

                entity.ToTable("play_history");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PlayHistories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__play_hist__user___6754599E");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.CommentParentId).HasColumnName("comment_parent_id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("content");

                entity.Property(e => e.PostDate)
                    .HasColumnType("datetime")
                    .HasColumnName("post_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.CommentParent)
                    .WithMany(p => p.InverseCommentParent)
                    .HasForeignKey(d => d.CommentParentId)
                    .HasConstraintName("FK__post__comment_pa__628FA481");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__post__user_id__619B8048");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GameId })
                    .HasName("PK__rating__564026F3D2AE7FDD");

                entity.ToTable("rating");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.Rating1).HasColumnName("rating");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__rating__user_id__7E37BEF6");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.PostId })
                    .HasName("PK__reviews__8C0C67B9F0C74160");

                entity.ToTable("reviews");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__reviews__post_id__06CD04F7");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
