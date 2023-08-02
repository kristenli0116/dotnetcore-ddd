using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Turakas.Infrastructure.Data.Identity;

namespace Turakas.Infrastructure.Data;

public class ApplicationDbContext:IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
{
   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
   {
      
   }

   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);
   }
}