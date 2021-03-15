using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_Library
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual Bug Bug { get; set; }
    }
}
