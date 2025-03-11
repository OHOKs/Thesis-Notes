using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telok.models
{
    [Table("telefon")]
    public class Telefon
    {
        [Key]
        public int Sorszam { get; set; }
        public string Marka { get; set; }
        public string Modell { get; set; }
        public int GyartasiEv { get; set; }
        public string Szin { get; set; }

        public int EladottDarab { get; set; }
        public decimal AtlagAr { get; set; }

    }
}
