using Microsoft.EntityFrameworkCore;
using StudentAPI.Entities;

namespace StudentAPI.DBcontexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>(entity =>
            //{
            //    entity.ToTable("Student");
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            //    entity.Property(e => e.Name).HasColumnType("nvarchar(50)").IsRequired();
            //});

            //modelBuilder.Entity<StudentCourse>(entity =>
            //{
            //    entity.ToTable("StudentCourse");
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            //});

            //modelBuilder.Entity<Course>(entity =>
            //{
            //    entity.ToTable("Course");
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            //});
            modelBuilder
                .Entity<StudentCourse>()
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder
                .Entity<StudentCourse>()
                .HasOne<Course>()
                .WithMany()
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
