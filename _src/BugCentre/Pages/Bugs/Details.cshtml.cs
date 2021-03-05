using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BugCentre.Data;
using DB_Context_Library;
using Entities_Library;

namespace BugCentre.PagesBugs
{
    public class DetailsModel : PageModel
    {
        private readonly BugCentreContext _context;

        public DetailsModel(BugCentreContext context)
        {
            _context = context;
        }

        public Bug Bug { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bug = await _context.Bugs.FirstOrDefaultAsync(m => m.BugID == id);

            if (Bug == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
