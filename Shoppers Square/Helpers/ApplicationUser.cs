using Microsoft.AspNetCore.Identity;

namespace Shoppers_Square.Helpers
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
