using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_Library
{
    //TODO: Tie these to users and eventually projects. Each user in a project an access all bugs in a project no matter who raised them

    public class Bug
    {
        public int BugID { get; set; }
        public string BugName { get; set; }
        public DateTime DateTimeReported { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        
        public virtual ICollection<Note> Notes { get; set; }
        public virtual Priority BugPriority { get; set; }
        //public virtual Project BugProject { get; set; }
        //public virtual User CreatedUser { get; set; }
    }
}