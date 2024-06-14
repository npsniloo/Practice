using System;
using System.Collections.Generic;
using BlazorAspCore.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorAspCore.Shared.Context;

public partial class ShoppingDBContext : DbContext
{
    public ShoppingDBContext()
    {
    }

    public ShoppingDBContext(DbContextOptions<ShoppingDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ItemDetail> ItemDetails { get; set; }

    public virtual DbSet<ShoppingDetail> ShoppingDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=ShoppingDB;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemDetail>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImageName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Image_Name");
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Item_Name");
            entity.Property(e => e.ItemPrice).HasColumnName("Item_Price");
        });

        modelBuilder.Entity<ShoppingDetail>(entity =>
        {
            entity.HasKey(e => e.ShopId);

            entity.Property(e => e.ShopId).HasColumnName("shopId");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.ShoppingDate)
                .HasColumnType("datetime")
                .HasColumnName("shoppingDate");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
