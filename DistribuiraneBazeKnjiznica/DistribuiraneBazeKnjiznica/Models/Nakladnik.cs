using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DistribuiraneBazeKnjiznica.Models
{
    [Table("dbo.Nakladnik")]
    public class Nakladnik
    {
        [Key]
        public int NakladnikID { get; set; }
        [Required]
        [RegularExpression("/^(?:HR)?(\\d{10}(\\d))$/", ErrorMessage = "Nije unesen ispravan OIB")]
        public string OIB { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public ICollection<Knjiga> Knjige { get; set; }
    }
}