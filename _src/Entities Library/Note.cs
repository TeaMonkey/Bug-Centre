using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_Library
{
    public class Note
    {
        public int NoteId { get; set; }
        public string NoteText { get; set; }

        public virtual Bug Bug { get; set; }
    }
}