using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
	public class Planner
	{
		//public int SpeakerId { get; set; }
		public int PlannerId { get; set; }
		public DateTime MeetingDate { get; set; }
		public int BishopricId { get; set; }
		public string OpenPrayer { get; set; }
		public string ClosePrayer { get; set; }

		public Bishopric Bishopric { get; set; }
		public ICollection<Speaker> Speakers { get; set; }
		public ICollection<Song> Songs { get; set; }
		//public ICollection<Bishopric> Bishoprics { get; set; } 
	}
}
