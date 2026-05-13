using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2
{
    public class AppDbContext : DbContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=albitar1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
   modelBuilder.HasDefaultSchema("task");


    modelBuilder.Entity<Students>().ToTable("Students");   
    modelBuilder.Entity<Teachers>().ToTable("Teachers");   
    modelBuilder.Entity<Courses>().ToTable("Courses");     
    modelBuilder.Entity<Enrollments>().ToTable("Enrollments"); 

    modelBuilder.Entity<Students>()
        .HasKey(s => s.StudentId);

    modelBuilder.Entity<Students>()
        .HasIndex(s => s.Email)
        .IsUnique();

    modelBuilder.Entity<Students>()
        .HasMany(s => s.Enrollments)
        .WithOne(e => e.Student)
        .HasForeignKey(e => e.StudentId);

    
    modelBuilder.Entity<Teachers>()
        .HasKey(t => t.TeacherId);

    modelBuilder.Entity<Teachers>()
        .HasIndex(t => t.Email)
        .IsUnique();

    modelBuilder.Entity<Teachers>()
        .Property(t => t.Department)
        .IsRequired();

    modelBuilder.Entity<Teachers>()
        .HasMany(t => t.Courses)
        .WithOne(c => c.Teacher)
        .HasForeignKey(c => c.TeacherId);


    modelBuilder.Entity<Courses>()
        .HasKey(c => c.CourseId);

    modelBuilder.Entity<Courses>()
        .HasMany(c => c.Enrollments)
        .WithOne(e => e.Course)
        .HasForeignKey(e => e.CourseId);

    modelBuilder.Entity<Enrollments>()
        .HasKey(e => e.EnrollmentId);

    modelBuilder.Entity<Enrollments>()
        .HasIndex(e => new { e.StudentId, e.CourseId })
        .IsUnique();
}
    }
}