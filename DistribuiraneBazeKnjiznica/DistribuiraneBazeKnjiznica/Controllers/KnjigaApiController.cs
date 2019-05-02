using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using DistribuiraneBazeKnjiznica.Models;

namespace DistribuiraneBazeKnjiznica.Controllers
{
    public class KnjigaApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Knjiga> Get()
        {
            var knjige = db.Knjiga.Include(k => k.Nakladnik).Include(k => k.Polica);

            return knjige.ToList();
        }
    }
}
