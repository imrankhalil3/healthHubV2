namespace SehatClone.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }

        public Hospital()
        {
            ImageUrl = "/Content/images/no-image.jpg";
        }
    }
}