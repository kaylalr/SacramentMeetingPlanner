using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
	public class Bishopric
	{
		public int BishopricId { get; set; }
		public Boolean Active { get; set; }
		public string BishopricName { get; set; }

		public ICollection<Planner> Planners { get; set; }
	}
}
