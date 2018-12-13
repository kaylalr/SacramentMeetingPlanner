using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Songs
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.MeetingContext _context;

        public EditModel(SacramentMeetingPlanner.Models.MeetingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Song Song { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Song = await _context.Songs.FirstOrDefaultAsync(m => m.SongId == id);

            if (Song == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
			if (!ModelState.IsValid)
			{
				return Page();
			}

			var songsToUpdate = await _context.Songs.FindAsync(id);

			if (await TryUpdateModelAsync<Song>(
				songsToUpdate,
				"songs",
				s => s.OpenSongNum, s => s.OpenSongTitle, s => s.CloseSongNum, s => s.CloseSongTitle, s => s.InterSongNum, s => s.InterSongTitle, s => s.SacramentSongNum, s => s.SacramentSongTitle, s => s.PlannerId))
			{
				await _context.SaveChangesAsync();
				//pass in id here??? I think I don't have to because in planners edit.cshtml.cs I do a request.query for the id if it's null when the method is called
				return RedirectToPage("/Planner/Edit", new { id = songsToUpdate.PlannerId });
			}

			return Page();
		}

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.SongId == id);
        }
    }
}
