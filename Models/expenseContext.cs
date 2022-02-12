using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExpenseTrackerNew.Models
{
    public partial class expenseContext : DbContext
    {
        public expenseContext()
        {
        }

        public expenseContext(DbContextOptions<expenseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemList> ItemList { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SREEHARIPRATHAP\\SQLEXPRESS;Database=expense;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Category1)
                    .HasColumnName("category")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Expenses>(entity =>
            {
                entity.HasKey(e => e.ExpenseId)
                    .HasName("PK__expenses__3672732E9A6AAFF7");

                entity.ToTable("expenses");

                entity.Property(e => e.ExpenseId).HasColumnName("expenseId");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.ExpenseAmount).HasColumnName("expenseAmount");

                entity.Property(e => e.ExpenseDate)
                    .HasColumnName("expenseDate")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__expenses__catego__4F7CD00D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__expenses__userId__4E88ABD4");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.ItemName)
                    .HasColumnName("itemName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnName("itemPrice");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__item__categoryId__4BAC3F29");
            });

            modelBuilder.Entity<ItemList>(entity =>
            {
                entity.ToTable("itemList");

                entity.Property(e => e.ItemListId).HasColumnName("itemListId");

                entity.Property(e => e.ExpenseId).HasColumnName("expenseId");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.ItemList)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("FK__itemList__expens__52593CB8");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemList)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__itemList__itemId__534D60F1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__users__CB9A1CFFD73EA600");

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
