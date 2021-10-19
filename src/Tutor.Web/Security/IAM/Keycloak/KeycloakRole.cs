using Microsoft.AspNetCore.Authorization;

namespace Tutor.Web.Security.IAM.Keycloak
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