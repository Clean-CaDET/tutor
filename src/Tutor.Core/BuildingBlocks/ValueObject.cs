using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.BuildingBlocks;

public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject one, ValueObject two)
    {
        return Equals(one, two);
    }

    public static bool operator !=(ValueObject one, ValueObject two)
    {
        return !Equals(one, two);
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }
}