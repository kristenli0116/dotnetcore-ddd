using Microsoft.AspNetCore.Identity;
using Turakas.Domain.SharedKernel;

namespace Turakas.Domain.Models.Auth;

public class FrameworkUser:IdentityUser<Guid>,IAggregateRoot
{
        
}