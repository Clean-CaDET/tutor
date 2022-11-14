using System;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges
{
    public sealed class ChallengeHint : IEquatable<ChallengeHint>
    {
        public int Id { get; private set; }
        public string Content { get; private set; }

        private ChallengeHint() { }
        public ChallengeHint(int id) : this()
        {
            Id = id;
        }

        public ChallengeHint(int id, string content) : this(id)
        {
            Content = content;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ChallengeHint);
        }

        public bool Equals(ChallengeHint hint)
        {
            return Id.Equals(hint.Id);
        }
    }
}
