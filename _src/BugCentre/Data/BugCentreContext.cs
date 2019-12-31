using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BugCentre.Data
{
    public class BugCentreContext: DbContext 
    {
        //public BugCentreContext(): base() {}
        public BugCentreContext(DbContextOptions<BugCentreContext> options) : base(options) { }
            
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}