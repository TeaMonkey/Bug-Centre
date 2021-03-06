using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugCentre.ViewModels
{
    public class BugVM
    {
        public int BugID { get; set; }
        public string BugName { get; set; }
        public DateTime DateTimeReported { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
