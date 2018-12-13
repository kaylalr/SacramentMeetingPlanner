using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
	public class Song
	{
		public int SongId { get; set; }
		public int PlannerId { get; set; }
		public int OpenSongNum { get; set; }
		public string OpenSongTitle { get; set; }
		public int SacramentSongNum { get; set; }
		public string SacramentSongTitle { get; set; }
		public int? InterSongNum { get; set; }
		// I think strings can be null by default
		public string InterSongTitle { get; set; }
		public int CloseSongNum { get; set; }
		public string CloseSongTitle { get; set; }
	}
}
