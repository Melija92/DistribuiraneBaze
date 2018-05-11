using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistribuiraneBazeKnjiznica.ViewModel
{
    public class KomentarViewModel
    {
        public int KomentarID { get; set; }
        [Required(ErrorMessage = "Tekst komentara obvezan je za unos!")]
        [StringLength(250, ErrorMessage = "Tekst komentara ne može biti veći od 250 znakova!")]
        public string Tekst { get; set; }
        public int KnjigaID { get; set; }
        public IEnumerable<KnjigaViewModel> Knjige { get; set; }
    }
}