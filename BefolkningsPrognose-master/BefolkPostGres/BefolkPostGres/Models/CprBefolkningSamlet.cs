using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BefolkPostGres.Models
{
    public partial class CprBefolkningSamlet
    {
        public short? KommuneNr { get; set; }
        public short? VejKode { get; set; }
        public string HusNr { get; set; }
        public decimal? Pnr { get; set; }
        public string Cpr { get; set; }
        public int? Alder { get; set; }
        public string Skoledisttext { get; set; }
        public decimal? Skolekod { get; set; }
        public string Befolkdisttext { get; set; }
        public decimal? Befolkkod { get; set; }
        public short? VejKode1 { get; set; }
        public string HusNr1 { get; set; }
        public string Tidligerekommune { get; set; }
        public double? Koornord { get; set; }
        public double? Kooroest { get; set; }
        public string Tilflytningsdatomarkering { get; set; }
        public string Civilstand { get; set; }
        public string Foedestedstekst { get; set; }
    }
}
