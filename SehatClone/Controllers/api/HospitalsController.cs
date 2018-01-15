using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SehatClone.Models;
using SehatClone.ViewModel;

namespace SehatClone.Controllers.api
{
    public class HospitalsController : ApiController
    {
        readonly ApplicationDbContext db;
        public HospitalsController()
        {
            db = new ApplicationDbContext();
        }

        public List<HomeSearchVm> GetHospitals(string query = null)
        {
            if (!string.IsNullOrEmpty(query))
            {
                var hospitalss = db.Hospitals.Where(d => d.IsApproved).ToList();
                var hospital = new List<HomeSearchVm>();
                foreach (var d in hospitalss)
                {
                    if (d.ContactName.ToLower().Contains(query.ToLower()))
                    {
                        hospital.Add(new HomeSearchVm { Name = d.ContactName, ImageUrl = d.ImageUrl });
                        continue;
                    }

                    if (d.Location.ToLower().Contains(query.ToLower()))
                    {
                        hospital.Add(new HomeSearchVm { Name = d.ContactName, ImageUrl = d.ImageUrl });
                        break;
                    }
                }
                return hospital.ToList();
            }

            return db.Hospitals.Select(d => new HomeSearchVm { Name = d.ContactName, ImageUrl = d.ImageUrl }).ToList();
        }
    }
}
