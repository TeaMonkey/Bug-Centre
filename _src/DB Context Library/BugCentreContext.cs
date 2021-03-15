using System;
using System.Collections.Generic;
using System.Text;
using Entities_Library;
using Microsoft.EntityFrameworkCore;

namespace DB_Context_Library
{
    public class BugCentreContext: DbContext 
    {
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Note> Notes { get; set; }

        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public BugCentreContext(DbContextOptions<BugCentreContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}