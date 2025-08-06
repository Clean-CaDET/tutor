namespace Tutor.Stakeholders.API.Dtos;

public class ChangePasswordDto
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}