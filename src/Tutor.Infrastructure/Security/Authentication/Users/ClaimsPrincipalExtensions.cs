using System.Linq;
using System.Security.Claims;

namespace Tutor.Infrastructure.Security.Authentication.Users;

public static class ClaimsPrincipalExtensions
{
    public static int LearnerId(this ClaimsPrincipal user)
        => int.Parse(user.Claims.First(i => i.Type == "learnerId").Value);
        
    public static int InstructorId(this ClaimsPrincipal user)
        => int.Parse(user.Claims.First(i => i.Type == "instructorId").Value);

    public static int Id(this ClaimsPrincipal user)
        => int.Parse(user.Claims.First(i => i.Type == "id").Value);
}