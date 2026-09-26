using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LeGiaHung2410900041_exam.Models;

public partial class LghStudentContext : DbContext
{
    public LghStudentContext()
    {
    }

    public LghStudentContext(DbContextOptions<LghStudentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LghStudent> LghStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AD\\SQLEXPRESS01;Database=LghStudent_2410900041_Db;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LghStudent>(entity =>
        {
            entity.ToTable("LghStudent");

            entity.Property(e => e.LghEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LghName).HasMaxLength(50);
            entity.Property(e => e.LghPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
