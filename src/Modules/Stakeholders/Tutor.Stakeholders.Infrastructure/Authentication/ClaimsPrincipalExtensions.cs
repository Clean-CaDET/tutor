using System.Security.Claims;

namespace Tutor.Stakeholders.Infrastructure.Authentication;

public static class ClaimsPrincipalExtensions
{
    public static int LearnerId(this ClaimsPrincipal user)
        => int.Parse(user.Claims.First(i => i.Type.StartsWith("learner")).Value);

    public static int InstructorId(this ClaimsPrincipal user)
        => int.Parse(user.Claims.First(i => i.Type == "instructorId").Value);
}