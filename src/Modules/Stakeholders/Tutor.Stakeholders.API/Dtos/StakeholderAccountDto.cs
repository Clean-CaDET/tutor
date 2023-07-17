namespace Tutor.Stakeholders.API.Dtos;

public class StakeholderAccountDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Index { get; set; }
    public bool IsArchived { get; set; }
    public string Password { get; set; }
    public string LearnerType { get; set; }
}