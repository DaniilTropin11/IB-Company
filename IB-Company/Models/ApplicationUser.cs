using Microsoft.AspNetCore.Identity;

namespace IB_Company.Models
{
    public class ApplicationUser  : IdentityUser
    {
        public string FullName {get;set; }
    }
}
