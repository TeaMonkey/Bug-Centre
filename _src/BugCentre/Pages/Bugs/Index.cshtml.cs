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
using BugCentre.ViewModels;

namespace BugCentre.PagesBugs
{
    public class IndexModel : PageModel
    {
        private readonly BugCentreContext _context;

        public IndexModel(BugCentreContext context)
        {
            _context = context;
        }

        public IList<BugVM> BugsVm { get;set; }

        public async Task OnGetAsync()
        {
            BugsVm = await _context.Bugs.Select(b => new BugVM { BugID = b.BugID, BugName = b.BugName, DateTimeReported = b.DateTimeReported, Description = b.Description, Image = b.Image }).ToListAsync();
        }
    }
}
