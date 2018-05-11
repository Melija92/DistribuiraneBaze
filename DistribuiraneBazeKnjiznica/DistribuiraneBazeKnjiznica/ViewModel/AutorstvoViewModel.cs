using DistribuiraneBazeKnjiznica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistribuiraneBazeKnjiznica.ViewModel
{
    public class AutorstvoViewModel
    {
        [Display(Name = "Vlasnik")]
        [Required(ErrorMessage = "Obvezno je odabrati knjigu!")]
        public int KnjigaID { get; set; }
        public IEnumerable<Knjiga> Knjige { get; set; }
        [Display(Name = "Autor")]
        [Required(ErrorMessage = "Obvezno je odabrati autora knjige!")]
        public int AutorID { get; set; }
        public IEnumerable<Autor> Autori { get; set; }
        public int UdioAutorstva { get; set; }
    }
}