using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DistribuiraneBazeKnjiznica.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Autorstvo> Autorstvo { get; set; }
        public DbSet<Knjiga> Knjiga { get; set; }
        public DbSet<Polica> Polica { get; set; }
        public DbSet<Nakladnik> Nakladnik { get; set; }

        public ApplicationDbContext()
        : base("DefaultConnection", throwIfV1Schema: false) { }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}