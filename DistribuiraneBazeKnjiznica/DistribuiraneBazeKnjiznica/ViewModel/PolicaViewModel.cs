using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistribuiraneBazeKnjiznica.ViewModel
{
    public class PolicaViewModel
    {
        public int PolicaID { get; set; }
        [Required(ErrorMessage = "Naziv police je obvezan za unos")]
        public string Oznaka { get; set; }
    }
}