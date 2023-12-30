using iRacing_API_Browser.Models;
using Microsoft.EntityFrameworkCore;

namespace iRacing_API_Browser.Data
{
    public class iRacingContext : DbContext
    {
        public iRacingContext(DbContextOptions<iRacingContext> options)
            : base(options)
        {
        }

        public DbSet<Track> Tracks { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
