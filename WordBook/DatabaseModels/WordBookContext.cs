﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WordBook.DatabaseModels
{
    public partial class WordBookContext : DbContext
    {
        public WordBookContext()
        {
        }

        public WordBookContext(DbContextOptions<WordBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<AchievementType> AchievementTypes { get; set; }
        public virtual DbSet<Box> Boxes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<RankType> RankTypes { get; set; }
        public virtual DbSet<Ranking> Rankings { get; set; }
        public virtual DbSet<SharedWord> SharedWords { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Word> Words { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=WordBook;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.AchievementType)
                    .WithMany(p => p.Achievements)
                    .HasForeignKey(d => d.AchievementTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Achieveme__Achie__656C112C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Achievements)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Achieveme__UserI__6477ECF3");
            });

            modelBuilder.Entity<AchievementType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Box>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Categorie__UserI__534D60F1");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.ContactFriends)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contacts__Friend__4CA06362");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ContactUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contacts__UserId__4BAC3F29");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Message1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Message");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.MessageReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__Receiv__5070F446");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.MessageSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__Sender__4F7CD00D");
            });

            modelBuilder.Entity<RankType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ranking>(entity =>
            {
                entity.HasKey(e => e.RankId)
                    .HasName("PK__Rankings__B37AF8769FBBEC49");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RankType)
                    .WithMany(p => p.Rankings)
                    .HasForeignKey(d => d.RankTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rankings__RankTy__693CA210");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rankings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rankings__UserId__68487DD7");
            });

            modelBuilder.Entity<SharedWord>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.SharedWordReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SharedWor__Recei__6D0D32F4");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.SharedWordSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SharedWor__Sende__6C190EBB");

                entity.HasOne(d => d.Word)
                    .WithMany(p => p.SharedWords)
                    .HasForeignKey(d => d.WordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SharedWor__WordI__6E01572D");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Types)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Types__UserId__5629CD9C");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateOfBirth)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Word>(entity =>
            {
                entity.Property(e => e.Meaning1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Meaning2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Meaning3)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Word1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Box)
                    .WithMany(p => p.Words)
                    .HasForeignKey(d => d.BoxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Words__BoxId__5DCAEF64");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Words)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Words__CategoryI__5BE2A6F2");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Words)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Words__TypeId__5CD6CB2B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Words)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Words__UserId__5AEE82B9");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}