using DistribuiraneBazeKnjiznica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistribuiraneBazeKnjiznica.ViewModel
{
    public class KnjigaViewModel
    {
        public int KnjigaID { get; set; }
        [Required(ErrorMessage = "Naziv knjige je obvezan za unos!")]
        public string Naziv { get; set; }
        public int BrojStranica { get; set; }
        public string JezikPisanja { get; set; }
        [Required(ErrorMessage = "Nakladnik je obvezan za unos!")]
        public int NakladnikID { get; set; }
        public IEnumerable<Nakladnik> Nakladnici { get; set; }
    }
}