﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DistribuiraneBazeKnjiznica.Models
{
    [Table("dbo.Autorstvo")]
    public class Autorstvo
    {
        [Key]
        [Column(Order = 1)]
        public int KnjigaID { get; set; }
        public virtual Knjiga Knjiga { get; set; }
        [Key]
        [Column(Order = 2)]
        public int AutorID { get; set; }
        public virtual Autor  Autor { get; set; }
        public int UdioAutorstva { get; set; }
    }
}