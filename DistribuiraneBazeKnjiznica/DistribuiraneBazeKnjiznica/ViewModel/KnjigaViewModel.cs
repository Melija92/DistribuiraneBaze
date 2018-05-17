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
        [Required(ErrorMessage = "Naziv knjige je obvezno za unos!")]
        public string Naziv { get; set; }
        public int Kolicina { get; set; }
        [Display(Name = "Broj stranica")]
        public int BrojStranica { get; set; }
        public string JezikPisanja { get; set; }
        [Display(Name = "Nakladnik")]
        public int NakladnikID { get; set; }
        public IEnumerable<Nakladnik> Nakladnici { get; set; }
        [Display(Name = "Polica")]
        public int PolicaID { get; set; }
        public IEnumerable<Polica> Police { get; set; }
    }
}