using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SehatClone.Models;

namespace SehatClone.Controllers.api
{
    public class DonorsController : ApiController
    {
        readonly ApplicationDbContext db;
        public DonorsController()
        {
            db = new ApplicationDbContext();
        }

        public List<Donor> GetDonors(string query = null)
        {
            if (!string.IsNullOrEmpty(query))
                return db.Donors.Where(d => (d.Name.ToLower().Contains(query) || d.Type.ToLower().Contains(query)) && d.IsApproved).ToList();

            return db.Donors.ToList();
        }
    }
}
