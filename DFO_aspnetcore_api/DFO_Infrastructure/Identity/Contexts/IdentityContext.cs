using DFO_Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DFO_Infrastructure.Identity.Contexts
{
    public class IdentityContext: IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }
    }
}