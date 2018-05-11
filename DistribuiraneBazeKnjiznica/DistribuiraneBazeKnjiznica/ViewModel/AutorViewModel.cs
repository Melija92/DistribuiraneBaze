using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistribuiraneBazeKnjiznica.ViewModel
{
    public class AutorViewModel
    {
        public int AutorID { get; set; }
        [Required(ErrorMessage = "OIB je obvezan za unos")]
        [RegularExpression("/^(?:HR)?(\\d{10}(\\d))$/", ErrorMessage = "Nije unesen ispravan OIB")]
        public string OIB { get; set; }
        [Required(ErrorMessage = "Ime je obvezno za unos")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obvezno za unos")]
        public string Prezime { get; set; }
    }
}