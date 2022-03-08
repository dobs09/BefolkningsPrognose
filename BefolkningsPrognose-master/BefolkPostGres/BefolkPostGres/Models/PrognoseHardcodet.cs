using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BefolkPostGres.Models
{
    public partial class PrognoseHardcodet
    {
        public int Id { get; set; }
        public string Omraade { get; set; }
        public int? Aarstal { get; set; }
        public string Maaned { get; set; }
        public int? Alder0 { get; set; }
        public int? Alder1 { get; set; }
        public int? Alder02 { get; set; }
        public int? Alder35 { get; set; }
        public int? Alder616 { get; set; }
        public int? Alder1724 { get; set; }
        public int? Alder2564 { get; set; }
        public int? Alder6574 { get; set; }
        public int? Alder7584 { get; set; }
        public int? Alder85 { get; set; }
        public int? Sum { get; set; }
    }
}
