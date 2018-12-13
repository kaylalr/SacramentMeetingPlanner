using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
	public class Speaker
	{
		public int SpeakerId { get; set; }
		public int PlannerId { get; set; }
		public string SpeakerName { get; set; }
		public string SpeakerTopic { get; set; }
	}
}
