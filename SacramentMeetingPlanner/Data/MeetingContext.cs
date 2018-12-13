using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SacramentMeetingPlanner.Models
{
    public class MeetingContext : DbContext
    {
        public MeetingContext (DbContextOptions<MeetingContext> options)
            : base(options)
        {
        }

        public DbSet<Planner> Planner { get; set; }
		public DbSet<Bishopric> Bishopric { get; set; }
		public DbSet<Speaker> Speakers { get; set; }
		public DbSet<Song> Songs { get; set; }
	}
}
