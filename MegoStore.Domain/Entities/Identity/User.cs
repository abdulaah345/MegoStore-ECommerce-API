using Microsoft.AspNetCore.Identity;

namespace MegoStore.Domain.Entities.Identity
{
    public class User:IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Address { get; set; }

    }
}
