using Assessment_RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_RaceTrack.Data
{
    public interface IRaceTrackContext
    {
        DbSet<Vehicle> Vehicles { get; set; }
        int SaveChanges();
        DbEntityEntry Entry(object entity);
    }
}
