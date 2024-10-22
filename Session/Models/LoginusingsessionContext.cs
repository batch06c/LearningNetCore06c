using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Session.Models;

public partial class LoginusingsessionContext : DbContext
{
    public LoginusingsessionContext()
    {
    }

    public LoginusingsessionContext(DbContextOptions<LoginusingsessionContext> options)
        : base(options)
    {

    }

    public DbSet<UserTbl> UserTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserTbl>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserTbl__1788CC4CF8A779CB");

            entity.ToTable("UserTbl");

            entity.Property(e => e.Gender)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
