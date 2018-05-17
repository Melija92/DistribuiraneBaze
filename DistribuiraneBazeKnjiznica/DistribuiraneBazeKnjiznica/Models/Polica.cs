﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DistribuiraneBazeKnjiznica.Models
{
    [Table("dbo.Polica")]
    public class Polica
    {
        [Key]
        public int PolicaID { get; set; }
        [Required]
        public string Oznaka { get; set; }
        public ICollection<Knjiga> Knjige { get; set; }
    }
}