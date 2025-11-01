using Microsoft.AspNetCore.Identity;

namespace CURD.Model
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}