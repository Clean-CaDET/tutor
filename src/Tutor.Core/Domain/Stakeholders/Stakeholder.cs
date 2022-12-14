using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Stakeholders;

public abstract class Stakeholder : Entity
{
    public int UserId { get; protected internal set; }
    public string Name { get; protected set; }
    public string Surname { get; protected set; }
    public string Email { get; protected set; }
}