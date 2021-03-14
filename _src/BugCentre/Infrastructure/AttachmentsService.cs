using DB_Context_Library;
using Entities_Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugCentre.Infrastructure
{
    public interface IAttachmentsService
    {
        Task<List<Attachment>> GetAttachments(int bugID);
    }

    public class AttachmentsService : IAttachmentsService
    {
        private readonly BugCentreContext _context;

        public AttachmentsService(BugCentreContext context)
        {
            _context = context;
        }

        public async Task<List<Attachment>> GetAttachments(int bugID)
        {
            return await _context.Attachments.Where(b => b.Bug.BugID == bugID).OrderBy(d => d.AttachmentId).ToListAsync();
        }

        public async Task<Attachment> GetPrimaryImage(int bugID)
        {
            //return await _context.Attachments.Single(b => b.Bug.BugID == bugID).OrderBy(d => d.AttachmentId)();

            throw new NotImplementedException();
        }
    }
}
