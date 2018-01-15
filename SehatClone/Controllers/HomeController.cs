using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SehatClone.Models;
using SehatClone.ViewModel;

namespace SehatClone.Controllers
{
    public class HomeController : Controller
    {
        readonly ApplicationDbContext db;

        public HomeController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Type)
                        .OrderByDescending(a => a.Id).Take(6).ToList();
            var vm = new HomeIndexVm { Articles = articles };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Search(SearchVm searchVm)
        {
            if (searchVm.UserType == "doctors")
            {
                var doctors = SearchDoctors(searchVm);
                return View("Doctors", doctors);
            }
            else if (searchVm.UserType == "centers")
            {
                var centers = SearchCenters(searchVm);
                return View("Centers", centers);
            }
            else if (searchVm.UserType == "hospitals")
            {
                var hospitals = SearchHospitals(searchVm);
                return View("Hospitals", hospitals);
            }

            var donors = SearchDonors(searchVm);
            return View("Donors", donors);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Terms()
        {
            return View();
        }

        List<Doctor> SearchDoctors(SearchVm searchVm)
        {
            var doctors = db.Doctors.Include(d => d.Speciality)
                .Where(d => (d.Name.ToLower().Contains(searchVm.SearchTxt.ToLower()) ||
                            d.Speciality.Select(c => c.Name.ToLower()).Contains(searchVm.SearchTxt.ToLower()) ||
                            searchVm.Location.ToLower().Contains(d.City.ToLower())) && d.IsApproved);

            return doctors.ToList();
        }

        List<Center> SearchCenters(SearchVm searchVm)
        {
            var centers = db.Centers.Include(c => c.Type)
                .Where(c => (c.Name.ToLower().Contains(searchVm.SearchTxt.ToLower()) ||
                            c.Type.Name.ToLower().Contains(searchVm.SearchTxt.ToLower()) ||
                            searchVm.Location.ToLower().Contains(c.City.ToLower())) && c.IsApproved);

            return centers.ToList();
        }

        List<Donor> SearchDonors(SearchVm searchVm)
        {
            var donors = db.Donors
                            .Where(c => (c.Name.ToLower().Contains(searchVm.SearchTxt.ToLower()) ||
                                         c.Type.ToLower().Contains(searchVm.SearchTxt.ToLower()) ||
                                         c.Location.ToLower().Contains(searchVm.Location.ToLower()))
                                         && c.IsApproved);
            return donors.ToList();
        }

        List<Hospital> SearchHospitals(SearchVm searchVm)
        {
            var hospitals = db.Hospitals
                            .Where(c => (c.ContactName.ToLower().Contains(searchVm.SearchTxt.ToLower()) ||
                                         c.Location.ToLower().Contains(searchVm.Location.ToLower()))
                                         && c.IsApproved);
            return hospitals.ToList();
        }
    }
}