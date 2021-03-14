using DB_Context_Library;
using Entities_Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugCentre.Infrastructure
{
    public interface ICommentsService
    {
        Task<List<Comment>> GetComments(int bugID);
    }

    public class CommentsService : ICommentsService
    {
        private readonly BugCentreContext _context;

        public CommentsService(BugCentreContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetComments(int bugID)
        {
            return await _context.Comments.Where(b => b.Bug.BugID == bugID).OrderBy(d => d.CommentId).ToListAsync();
        }
    }
}
