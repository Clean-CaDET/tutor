using Microsoft.AspNetCore.Authorization;

namespace Tutor.Web.Controllers.KeycloakAuth
{
    public class KeycloakRole : IAuthorizationRequirement
    {
        public KeycloakRole(string role)
        {
            AllowedRole = role;
        }

        public string AllowedRole { get; }
    }
}