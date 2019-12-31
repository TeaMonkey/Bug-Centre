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
    public class IndexModel : PageModel
    {
        private readonly BugCentre.Data.BugCentreContext _context;

        public IndexModel(BugCentre.Data.BugCentreContext context)
        {
            _context = context;
        }

        public IList<Bug> Bug { get;set; }

        public async Task OnGetAsync()
        {
            Bug = await _context.Bugs.ToListAsync();
        }
    }
}
