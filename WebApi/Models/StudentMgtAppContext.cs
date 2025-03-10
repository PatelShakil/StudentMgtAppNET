using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models;

public partial class StudentMgtAppContext : DbContext
{
    private IConfiguration configuration;

    public StudentMgtAppContext(DbContextOptions<StudentMgtAppContext> options,IConfiguration configuration)
        : base(options)
    {
        this.configuration = configuration;
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(configuration["ConnectionStrings:StudentDB"]);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.EnrollmentNo);

            entity.ToTable("Student");

            entity.Property(e => e.EnrollmentNo).ValueGeneratedNever();
            entity.Property(e => e.Achievement).HasMaxLength(1);
            entity.Property(e => e.City).HasMaxLength(1);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State).HasMaxLength(1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
