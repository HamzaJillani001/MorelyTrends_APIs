
using Microsoft.AspNetCore.Identity;

namespace MorelyTrends.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gender { get; set; }
    }
}
