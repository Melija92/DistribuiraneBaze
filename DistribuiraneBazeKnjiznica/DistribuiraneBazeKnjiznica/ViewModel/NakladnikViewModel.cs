using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistribuiraneBazeKnjiznica.ViewModel
{
    public class NakladnikViewModel
    {
        public int NakladnikID { get; set; }
        [Required]
        [RegularExpression("/^(?:HR)?(\\d{10}(\\d))$/", ErrorMessage = "Nije unesen ispravan OIB")]
        public string OIB { get; set; }
        [Required(ErrorMessage = "Naziv nakladnika je obvezan za unos")]
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    }
}