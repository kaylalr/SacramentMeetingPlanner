using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Speakers
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.MeetingContext _context;

        public EditModel(SacramentMeetingPlanner.Models.MeetingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Speaker Speaker { get; set; }
        public int PlannerId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? PlannerId)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (PlannerId != null)
            {
                PlannerId = PlannerId.Value;
            }

            Speaker = await _context.Speakers.FirstOrDefaultAsync(m => m.SpeakerId == id);

            if (Speaker == null)
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

            var speakersToUpdate = await _context.Speakers.FindAsync(id);

            if (await TryUpdateModelAsync<Speaker>(
                speakersToUpdate,
                "speaker",
                s => s.SpeakerName, s => s.SpeakerTopic))
            {
                await _context.SaveChangesAsync();
                //pass in id here??? I think I don't have to because in planners edit.cshtml.cs I do a request.query for the id if it's null when the method is called
                return RedirectToPage("/Planners/Edit", new { id = speakersToUpdate.PlannerId });
            }

            return Page();
        }

        private bool SpeakerExists(int id)
        {
            return _context.Speakers.Any(e => e.SpeakerId == id);
        }
    }
}
