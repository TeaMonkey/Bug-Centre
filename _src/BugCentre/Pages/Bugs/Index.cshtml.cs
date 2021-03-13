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
using BugCentre.Infrastructure;
using BugCentre.Pages.Shared;

namespace BugCentre.PagesBugs
{
    public class IndexModel : PageModel
    {
        private readonly IBugService _bugService;

        public IndexModel(IBugService bugService)
        {
            _bugService = bugService;
        }

        public IList<BugVM> BugsVm { get;set; }
        public _PagingPartialModel paging { get; set; } = new _PagingPartialModel();

        public async Task OnGetAsync(int CurrentPage = 1)
        {
            paging.CurrentPage = CurrentPage;

            List<Bug> Bugs = await _bugService.GetPaginatedResult(paging.CurrentPage, paging.PageSize);
            BugsVm = Bugs.Select(b => new BugVM { BugID = b.BugID, BugName = b.BugName, DateTimeReported = b.DateTimeReported, Description = b.Description, Image = b.Image }).ToList();
            paging.Count = await _bugService.GetCount();
        }
    }
}
