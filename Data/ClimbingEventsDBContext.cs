using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KlimEvenementenAPI.Models;

namespace KlimEvenementenAPI.Data
{
        public class ClimbingEventsDBContext : DbContext
        {
            public ClimbingEventsDBContext(DbContextOptions<ClimbingEventsDBContext> options) : base(options) { }
            public DbSet<ClimbingEvent> ClimbingEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseSeeding((context, _) =>
        {
            ClimbingEvents.Add(new KlimEvenementenAPI.Models.ClimbingEvent() { Id = 0, Name = "test" });
            SaveChanges();
        });
    }
}
