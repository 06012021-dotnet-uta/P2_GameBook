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

        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<CollectionJunction> CollectionJunctions { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<GenreJunction> GenreJunctions { get; set; }
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<KeywordJunction> KeywordJunctions { get; set; }
        public virtual DbSet<PlayHistory> PlayHistories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("collection");

                entity.Property(e => e.CollectionId)
                    .ValueGeneratedNever()
                    .HasColumnName("collection_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<CollectionJunction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("collection_junction");

                entity.Property(e => e.CollectionId).HasColumnName("collection_id");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.HasOne(d => d.Collection)
                    .WithMany()
                    .HasForeignKey(d => d.CollectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__collectio__colle__70DDC3D8");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__collectio__game___71D1E811");
            });

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("friend");

                entity.Property(e => e.User1Id).HasColumnName("user1_id");

                entity.Property(e => e.User2Id).HasColumnName("user2_id");

                entity.HasOne(d => d.User1)
                    .WithMany()
                    .HasForeignKey(d => d.User1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__friend__user1_id__5DCAEF64");

                entity.HasOne(d => d.User2)
                    .WithMany()
                    .HasForeignKey(d => d.User2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__friend__user2_id__5EBF139D");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.Property(e => e.GameId)
                    .ValueGeneratedNever()
                    .HasColumnName("game_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.GenreId)
                    .ValueGeneratedNever()
                    .HasColumnName("genre_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<GenreJunction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("genre_junction");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__genre_jun__game___6D0D32F4");

                entity.HasOne(d => d.Genre)
                    .WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__genre_jun__genre__6C190EBB");
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.ToTable("keyword");

                entity.Property(e => e.KeywordId)
                    .ValueGeneratedNever()
                    .HasColumnName("keyword_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<KeywordJunction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("keyword_junction");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.KeywordId).HasColumnName("keyword_id");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__keyword_j__game___76969D2E");

                entity.HasOne(d => d.Keyword)
                    .WithMany()
                    .HasForeignKey(d => d.KeywordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__keyword_j__keywo__75A278F5");
            });

            modelBuilder.Entity<PlayHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("play_history");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__play_hist__game___68487DD7");

                entity.HasOne(d => d.User)
                    .WithMany()
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

                entity.Property(e => e.Rating).HasColumnName("rating");

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
