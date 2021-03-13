using DB_Context_Library;
using Entities_Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugCentre.Infrastructure
{
    public interface IBugService
    {
        Task<List<Bug>> GetPaginatedResult(int currentPage, int pageSize = 2);
        Task<int> GetCount();
    }

    public class BugService : IBugService
    {
        private readonly BugCentreContext _context;

        public BugService(BugCentreContext context)
        {
            _context = context;
        }

        public async Task<List<Bug>> GetPaginatedResult(int currentPage, int pageSize = 10)
        {
            return await _context.Bugs.OrderBy(d => d.BugID).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.Bugs.CountAsync();
        }
    }
}
