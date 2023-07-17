namespace Tutor.BuildingBlocks.Core.Domain;

public abstract class Entity
{
    public int Id { get; protected set; }

    public override bool Equals(object? obj)
    {
        return obj is Entity entity && Id.Equals(entity.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}