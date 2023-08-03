namespace Tutor.Stakeholders.API.Dtos;

public class AuthenticationTokensDto
{
    public int Id { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}