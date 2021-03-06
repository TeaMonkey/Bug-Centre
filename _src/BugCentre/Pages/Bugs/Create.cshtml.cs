using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BugCentre.Data;
using Microsoft.AspNetCore.Authorization;
using DB_Context_Library;
using Entities_Library;
using Microsoft.AspNetCore.Http;
using BugCentre.ViewModels;
using System.IO;

namespace BugCentre.PagesBugs
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly BugCentreContext _context;

        public CreateModel(BugCentreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BugCreateVM BugCreateVm { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (BugCreateVm.UploadedImage.Length > 0)
            {
                //TODO: Put this in a helper

                using (var ms = new MemoryStream())
                {
                    BugCreateVm.UploadedImage.CopyTo(ms);
                    //var fileBytes = ms.ToArray();
                    //string s = Convert.ToBase64String(fileBytes);
                    BugCreateVm.Image = ms.ToArray();
                }
            }

            var entry = _context.Add(new Bug());
            entry.CurrentValues.SetValues(BugCreateVm);

            //_context.Bugs.Add(BugVm);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
