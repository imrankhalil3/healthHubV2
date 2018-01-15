using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using SehatClone.Models;
using SehatClone.ViewModel;

namespace SehatClone.Controllers.api
{
    public class CentersController : ApiController
    {
        readonly ApplicationDbContext db;
        public CentersController()
        {
            db = new ApplicationDbContext();
        }

        public List<HomeSearchVm> GetCenters(string query = null)
        {
            if (!string.IsNullOrEmpty(query))
            {
                var centerss = db.Centers.Include(c => c.Type).Where(d => d.IsApproved).ToList();
                var centers = new List<HomeSearchVm>();
                foreach (var d in centerss)
                {
                    if (d.Name.ToLower().Contains(query.ToLower()))
                    {
                        centers.Add(new HomeSearchVm { Name = d.Name, ImageUrl = d.ImageUrl });
                        continue;
                    }

                    if (d.Type.Name.ToLower().Contains(query.ToLower()))
                    {
                        centers.Add(new HomeSearchVm { Name = d.Name, ImageUrl = d.ImageUrl });
                        break;
                    }
                }
                return centers.ToList();
            }

            return db.Centers.Select(d => new HomeSearchVm { Name = d.Name, ImageUrl = d.ImageUrl }).ToList();
        }
    }
}
