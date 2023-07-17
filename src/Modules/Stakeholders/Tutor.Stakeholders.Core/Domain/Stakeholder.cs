using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Stakeholders.Core.Domain;

public abstract class Stakeholder : Entity
{
    public int UserId { get; protected internal set; }
    public string Name { get; protected set; }
    public string Surname { get; protected set; }
    public string? Email { get; protected set; }
    public bool IsArchived { get; set; }
}