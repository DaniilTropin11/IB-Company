using Microsoft.AspNetCore.Identity;

namespace IBCompany_Models
{
    public class ApplicationUser  : IdentityUser
    {
        public string FullName {get;set; }
    }
}
