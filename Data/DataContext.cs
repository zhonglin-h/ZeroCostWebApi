using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace testWebAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet <Entities.Student> Students { get; set; }
    }
}
