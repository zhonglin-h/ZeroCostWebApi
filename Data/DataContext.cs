using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace testWebAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet <Entities.Student> Students { get; set; }

        public DbSet<Entities.Course> Courses { get; set; }

        public DbSet<Entities.CourseEnrollment> CourseEnrollments { get; set; }
    }
}
