using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BugCentre.Data;

namespace BugCentre.PagesBugs
{
    public class DeleteModel : PageModel
    {
        private readonly BugCentre.Data.BugCentreContext _context;

        public DeleteModel(BugCentre.Data.BugCentreContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bug = await _context.Bugs.FindAsync(id);

            if (Bug != null)
            {
                _context.Bugs.Remove(Bug);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
