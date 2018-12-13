using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Songs
{
    public class CreateModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.MeetingContext _context;

        public CreateModel(SacramentMeetingPlanner.Models.MeetingContext context)
        {
            _context = context;
        }

		//[HttpGet("")]
		public IActionResult OnGet()
		{
			
            return Page();
        }

        [BindProperty]
        public Song Song { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
			if (!ModelState.IsValid)
			{
				return Page();
			}
			
			var emptySongs = new Song();

			if (await TryUpdateModelAsync<Song>(
				emptySongs,
				"song",   // Prefix for form value.
				s => s.OpenSongNum, s => s.OpenSongTitle, s => s.CloseSongNum, s => s.CloseSongTitle, s => s.InterSongNum, s => s.InterSongTitle, s => s.SacramentSongNum, s => s.SacramentSongTitle, s => s.PlannerId))
			{
				_context.Songs.Add(emptySongs);
				await _context.SaveChangesAsync();

				return RedirectToPage("/Planners/Edit", new { id = emptySongs.PlannerId });
			}

			return RedirectToPage("/Planners/Edit");
		}
    }
}