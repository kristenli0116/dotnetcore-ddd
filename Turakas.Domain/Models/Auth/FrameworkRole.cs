using Microsoft.AspNetCore.Identity;
using Turakas.Domain.SharedKernel;

namespace Turakas.Domain.Models.Auth;

public class FrameworkRole:IdentityRole<Guid>,IAggregateRoot
{
    
}