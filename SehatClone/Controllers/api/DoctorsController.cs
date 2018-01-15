using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using SehatClone.Models;
using SehatClone.ViewModel;

namespace SehatClone.Controllers.api
{
    public class DoctorsController : ApiController
    {
        readonly ApplicationDbContext db;
        public DoctorsController()
        {
            db = new ApplicationDbContext();
        }

        public List<HomeSearchVm> GetDoctors(string query = null)
        {
            if (!string.IsNullOrEmpty(query))
            {

                var doctorss = db.Doctors.Include(d => d.Speciality).Where(d => d.IsApproved).ToList();
                var doctors = new List<HomeSearchVm>();
                foreach (var d in doctorss)
                {
                    if (d.Name.ToLower().Contains(query.ToLower()))
                    {
                        doctors.Add(new HomeSearchVm { Name = d.Name, ImageUrl = d.ImageUrl });
                        continue;
                    }

                    foreach (var s in d.Speciality)
                    {
                        if (s.Name.ToLower().Contains(query.ToLower()))
                        {
                            doctors.Add(new HomeSearchVm { Name = d.Name, ImageUrl = d.ImageUrl });
                            break;
                        }
                    }
                }

                return doctors.ToList();
            }

            return db.Doctors.Select(d => new HomeSearchVm { Name = d.Name, ImageUrl = d.ImageUrl }).ToList();
        }
    }
}
