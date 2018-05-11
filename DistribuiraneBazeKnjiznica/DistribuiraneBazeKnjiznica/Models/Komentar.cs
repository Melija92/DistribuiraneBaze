using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DistribuiraneBazeKnjiznica.Models
{
    [Table("dbo.Komentar")]
    public class Komentar
    {
        [Key]
        public int KomentarID { get; set; }
        [Required, StringLength(40)]
        public string Tekst { get; set; }
        public int KnjigaID { get; set; }
        public virtual Knjiga Knjiga { get; set; }
    }
}