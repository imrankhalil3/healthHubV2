using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using SehatClone.Models;
using SehatClone.ViewModel;

namespace SehatClone.Controllers
{
    public class HospitalsController : Controller
    {
        readonly ApplicationDbContext db;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public HospitalsController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Detail(int id)
        {
            var hospital = db.Hospitals.SingleOrDefault(d => d.Id == id && d.IsApproved);

            if (hospital == null)
                return HttpNotFound("Hospital Not Found");

            return View(hospital);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(CreateHospitalVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var hospital = new Hospital();
            hospital.ContactName = vm.ContactName;
            hospital.Email = vm.Email;
            hospital.Password = vm.Password;
            hospital.ConfirmPassword = vm.ConfirmPassword;
            hospital.Phone = vm.Phone;
            hospital.Location = vm.Location;
            hospital.ImageUrl = vm.ImageUrl;
            hospital.Description = vm.Description;
            hospital.IsApproved = false;

            db.Hospitals.Add(hospital);
            db.SaveChanges();

            var user = new ApplicationUser { UserName = vm.Email, Email = vm.Email };
            var result = await UserManager.CreateAsync(user, vm.Password);
            if (result.Succeeded)
                return RedirectToAction("Login");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error);

            return View(vm);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var hospital = db.Hospitals.SingleOrDefault(d => d.Email == model.Email && d.Password == model.Password);

            if (hospital == null)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            if (!hospital.IsApproved)
            {
                ModelState.AddModelError("", "Not Approved By Admin Yet");
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }
    }
}