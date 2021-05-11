using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibraryApp.Models
{
    public class LibraryIdentityDBContext : IdentityDbContext<IdentityUser>
    {
        public LibraryIdentityDBContext (DbContextOptions<LibraryIdentityDBContext> options) : base (options)
        {

        }
    }
}
