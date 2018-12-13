using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.MeetingContext _context;

        public IndexModel(SacramentMeetingPlanner.Models.MeetingContext context)
        {
            _context = context;
        }

        public IList<Song> Song { get;set; }

        public async Task OnGetAsync()
        {
            Song = await _context.Songs.ToListAsync();
        }
    }
}
