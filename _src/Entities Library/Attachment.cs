using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_Library
{
    public class Attachment
    {
        public int AttachmentId { get; set; }
        public byte[] FileContent { get; set; }

        public string FileType { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public virtual Bug Bug { get; set; }
    }
}
