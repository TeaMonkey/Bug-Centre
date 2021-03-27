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
using BugCentre.Infrastructure;
using BugCentre.ViewModels;

namespace BugCentre.PagesBugs
{
    public class DetailsModel : PageModel
    {
        private readonly BugCentreContext _context;
        private readonly IPdfService _pdfService;

        public DetailsModel(BugCentreContext context, IPdfService pdfService)
        {
            _context = context;
            _pdfService = pdfService;
        }

        public BugVM BugVm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BugVm = await _context.Bugs.Select(b => new BugVM { BugID = b.BugID, BugName = b.BugName, DateTimeReported = b.DateTimeReported, Description = b.Description, Image = b.Image }).FirstOrDefaultAsync(m => m.BugID == id);

            if (BugVm == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<FileContentResult> OnGetPdf(int id)
        {
            byte[] pdf = await _pdfService.GetAsPdf(id);

            return File(pdf, "application/pdf", $"Bug {id}.pdf");
        }
    }
}
