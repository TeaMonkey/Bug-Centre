using BugCentre.ViewModels;
using DB_Context_Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BugCentre.PagesBugs
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly BugCentreContext _context;

        public EditModel(BugCentreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BugEditVM BugEditVm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BugEditVm = await _context.Bugs.Select(b => new BugEditVM { BugID = b.BugID, BugName = b.BugName, DateTimeReported = b.DateTimeReported, Description = b.Description, Image = b.Image }).FirstOrDefaultAsync(m => m.BugID == id);

            if (BugEditVm == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //TODO - Eventually add a check here to make sure the current user has access to this bug
            var bugToUpdate = await _context.Bugs.FindAsync(BugEditVm.BugID);

            if (bugToUpdate == null)
            {
                return NotFound();
            }

            if (BugEditVm.UploadedImage?.Length > 0)
            {
                //TODO: Put this in a helper

                using (var ms = new MemoryStream())
                {
                    BugEditVm.UploadedImage.CopyTo(ms);
                    BugEditVm.Image = ms.ToArray();
                }
            }

            MapVmToModel(bugToUpdate);

            //if (await TryUpdateModelAsync<Bug>(bugToUpdate, "", b => b.BugName, b => b.DateTimeReported, b => b.Description, b => b.Image))
            //{
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!BugExists(BugEditVm.BugID))
                //{
                //    return NotFound();
                //}
                //else
                //{
                throw;
                //}
            }
            //  }

            return RedirectToPage("./Index");
        }

        private void MapVmToModel(Entities_Library.Bug bugToUpdate)
        {
            bugToUpdate.BugName = BugEditVm.BugName;
            bugToUpdate.DateTimeReported = BugEditVm.DateTimeReported;
            bugToUpdate.Description = BugEditVm.Description;

            if (BugEditVm.Image != null)
                bugToUpdate.Image = BugEditVm.Image;

            if (BugEditVm.DeleteImage)
                bugToUpdate.Image = null;
        }

        //private bool BugExists(int id)
        //{
        //    return _context.Bugs.Any(e => e.BugID == id);
        //}
    }
}
