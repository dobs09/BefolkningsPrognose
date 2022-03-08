using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BefolkPostGres.Models
{
    public partial class Skolestoerrelse
    {
        public string FlisKommune { get; set; }
        public float? FlisGnsSkolestoerrelse { get; set; }
        public int OgcFid { get; set; }
    }
}
