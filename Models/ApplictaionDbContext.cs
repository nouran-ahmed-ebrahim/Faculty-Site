using Microsoft.EntityFrameworkCore;

namespace Asp.net.Models
{
    public class ApplictaionDbContext : DbContext
    {
	public ApplictaionDbContext ():base()
        {

        }
        public ApplictaionDbContext (DbContextOptions options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-9P4J4BR;Initial Catalog=Faculty;Integrated Security=True; TrustServerCertificate=True;");

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructore> Instructores { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CoursesResult> CoursesResults { get; set; }
    }
}
