using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MapMyData.Data.Models
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<MapDataSet> DataSets { get; set; }
        public DbSet<DataPoint> DataPoints { get; set; }
        public DbSet<State> States { get; set; }
    }
}
