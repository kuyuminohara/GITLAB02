using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LghLesson10EFCDBFirst.Models;

public partial class LghLesson10Context : DbContext
{
    public LghLesson10Context()
    {
    }

    public LghLesson10Context(DbContextOptions<LghLesson10Context> options)
        : base(options)
    {
    }

    public virtual DbSet<LghMember> LghMembers { get; set; }

    /// <param name="optionsBuilder">The builder being used to create the context.</param>
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //> optionsBuilder.UseSqlServer("Server=AD\\SQLEXPRESS01;Database=LghLesson10EFDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LghMember>(entity =>
        {
            entity.ToTable("LghMember");

            entity.Property(e => e.LghEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LghFullName).HasMaxLength(50);
            entity.Property(e => e.LghPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LghPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LghUserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
