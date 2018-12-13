using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;


namespace SacramentMeetingPlanner.Pages.Planners
{
    public class DetailsModel : PageModel
    {
        private readonly MeetingContext _context;

        public DetailsModel(MeetingContext context)
        {
            _context = context;
        }

        public Planner Planner { get; set; }
		public Bishopric Bishopric { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			//Planner = await _context.Planner.FirstOrDefaultAsync(m => m.PlannerId == id);
			
			// what is this doing???
			Planner = await _context.Planner
						//.Include(b => b.Bishopric)
						//.ThenInclude(e => e.Speakers)
						.Include(s => s.Speakers)
						//.ThenInclude(sn => sn.SpeakerName)
						//.ThenInclude(st => st.SpeakerTopic)
						.Include(s => s.Songs)
						.AsNoTracking()
						.FirstOrDefaultAsync(m => m.PlannerId == id);

			Bishopric = await _context.Bishopric.FirstOrDefaultAsync(m => m.BishopricId == Planner.Bishopric);

			if (Planner == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
