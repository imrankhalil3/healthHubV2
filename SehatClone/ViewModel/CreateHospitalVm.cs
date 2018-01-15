using System.ComponentModel.DataAnnotations;

namespace SehatClone.ViewModel
{
    public class CreateHospitalVm
    {
        [Required]
        public string ContactName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password Dosent Match")]
        public string ConfirmPassword { get; set; }

        public string Location { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }
    }
}