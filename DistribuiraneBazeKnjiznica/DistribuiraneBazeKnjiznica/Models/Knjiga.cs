using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DistribuiraneBazeKnjiznica.Models
{
    [Table("dbo.Knjiga")]
    public class Knjiga
    {
        [Key]
        public int KnjigaID { get; set; }
        public string Naziv { get; set; }
        public int BrojStranica { get; set; }
        public string JezikPisanja { get; set; }
        public int NakladnikID { get; set; }
        public virtual Nakladnik Nakladnici { get; set; }
        public ICollection<Autorstvo> Iznajmljivanja { get; set; }
    }
}