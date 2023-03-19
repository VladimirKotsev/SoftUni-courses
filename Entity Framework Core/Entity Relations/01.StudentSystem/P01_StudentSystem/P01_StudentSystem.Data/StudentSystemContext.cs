namespace P01_StudentSystem.Data;

using Microsoft.EntityFrameworkCore;

using P01_StudentSystem.Data.Common;
using P01_StudentSystem.Data.Models;

public class StudentSystemContext : DbContext
{
    public StudentSystemContext()
    {

    }

    public StudentSystemContext(DbContextOptions options) 
        : base(options)
    {

    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Homework> Homeworks { get; set; }
    public DbSet<StudentCourse> StudentsCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(DbConfig.connectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>(entity =>
        {
            entity
                .Property(s => s.Name)
                .IsUnicode(true);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity
                .Property(c => c.Name)
                .IsUnicode(true);     
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity
                .Property(r => r.Name)
                .IsUnicode(true);
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
        });
    }

}
