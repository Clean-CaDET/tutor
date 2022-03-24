using System.Linq;
using System.Security.Claims;

namespace Tutor.Infrastructure.Security.Authorization.JWT
{
    public static class ClaimsPrincipalExtensions
    {
        public static int Id(this ClaimsPrincipal user)
            => int.Parse(user.Claims.First(i => i.Type == "id").Value);
    }
}
