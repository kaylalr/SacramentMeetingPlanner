using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
	public class Speaker
	{
		public int SpeakerId { get; set; }
		public int PlannerId { get; set; }

        [Required]
        [StringLength(80)]
        public string SpeakerName { get; set; }

        [Required]
        [StringLength(50)]
        public string SpeakerTopic { get; set; }
	}
}
