using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SehatClone.Models;
using SehatClone.ViewModel;

namespace SehatClone.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        readonly ApplicationDbContext db;

        public AdminController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var centers = db.Centers
                .Include(c => c.Services)
                .Include(c => c.Type)
                .ToList();

            var doctors = db.Doctors.Include(d => d.Speciality).ToList();

            var donors = db.Donors.ToList();
            var hospitals = db.Hospitals.ToList();

            var viewModel = new AdminIndexVm
            {
                Centers = centers,
                Doctors = doctors,
                Donors = donors,
                Hospitals = hospitals
            };

            return View(viewModel);
        }

        public ActionResult ApproveDoctor(int id)
        {
            var doctor = db.Doctors.Find(id);

            if (doctor == null)
                return HttpNotFound("Doctor Not Found !");

            doctor.IsApproved = true;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ApproveCenter(int id)
        {
            var center = db.Centers.Find(id);

            if (center == null)
                return HttpNotFound("Center Not Found !");

            center.IsApproved = true;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ApproveDonor(int id)
        {
            var donor = db.Donors.Find(id);

            if (donor == null)
                return HttpNotFound("Donor Not Found !");

            donor.IsApproved = true;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ApproveHospital(int id)
        {
            var hospital = db.Hospitals.Find(id);

            if (hospital == null)
                return HttpNotFound("Hospital Not Found !");

            hospital.IsApproved = true;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}