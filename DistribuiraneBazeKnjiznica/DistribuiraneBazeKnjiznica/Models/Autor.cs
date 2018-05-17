using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DistribuiraneBazeKnjiznica.Models
{
    [Table("dbo.Autor")]
    public class Autor
    {
        [Key]
        public int AutorID { get; set; }
        [Required]
        public string OIB { get; set; }
        [Required, StringLength(40)]
        public string Ime { get; set; }
        [Required, StringLength(40)]
        public string Prezime { get; set; }
        public ICollection<Autorstvo> Iznajmljivanja { get; set; }
    }
}