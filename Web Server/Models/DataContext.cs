using Microsoft.EntityFrameworkCore;
namespace Web_Server.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
            public DbSet<Device> Devices { get; set; }
        
    }
}
