using Microsoft.AspNetCore.Identity;

namespace WebAppMonofia2025.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
        //public Employee MyProperty { get; set; }
    }
}
