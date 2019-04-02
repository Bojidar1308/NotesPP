using System;
using System.Collections.Generic;

namespace NotesPP
{
    public partial class Notes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string AccUsername { get; set; }
        public byte? IsArchived { get; set; }
    }
}
