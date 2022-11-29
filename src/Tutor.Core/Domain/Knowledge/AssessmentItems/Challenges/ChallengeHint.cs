using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges;

public sealed class ChallengeHint : ValueObject
{
    public int Id { get; private set; }
    public string Content { get; private set; }

    public ChallengeHint(int id, string content)
    {
        Id = id;
        Content = content;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Content;
    }
}