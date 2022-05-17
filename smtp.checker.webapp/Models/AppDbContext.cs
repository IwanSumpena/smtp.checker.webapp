using Microsoft.EntityFrameworkCore;

namespace smtp.checker.webapp.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<SendEmailLog> SendEmailLogs { get; set; }
    }
}
