using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Stakeholders;

public class Instructor : Entity
{
    public int UserId { get; protected set; }
    public string Name { get; protected set; }
    public string Surname { get; protected set; }
}