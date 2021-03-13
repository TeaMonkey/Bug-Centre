using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugCentre.ViewModels
{
    public class BugVM
    {
        public int BugID { get; set; }

        [Display(Name = "Name")]
        public string BugName { get; set; }

        [Display(Name = "DateTime Reported")]
        public DateTime DateTimeReported { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }
    }
}
