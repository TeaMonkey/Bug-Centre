using DB_Context_Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BugCentre.Infrastructure
{
    public interface IPdfService
    {
        Task<byte[]> GetAsPdf(int bugID);
    }

    public class PdfService : IPdfService
    {
        private readonly BugCentreContext _context;

        public PdfService(BugCentreContext context)
        {
            _context = context;
        }

        public async Task<byte[]> GetAsPdf(int bugID)
        {
            var bug = await _context.Bugs.FirstOrDefaultAsync(b => b.BugID == bugID);

            if (bug != null)
            {
                var renderer = new IronPdf.HtmlToPdf();
                var doc = await renderer.RenderHtmlAsPdfAsync("<h1>Html with CSS and Images</h1>");

                using (MemoryStream stream = doc.Stream)
                {
                    return stream.ToArray();
                }
            }

            return null;
        }
    }
}
