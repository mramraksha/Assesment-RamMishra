using Assessment_RaceTrack.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Assessment_RaceTrack.Data
{
    public class RaceTrackContext : DbContext, IRaceTrackContext
    {
        public RaceTrackContext() : base("RaceTrackConString")
        { }
        public DbSet<Vehicle> Vehicles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    
}
