using CodeModel.CaDETModel;
using CodeModel.CaDETModel.CodeItems;
using System;
using System.Linq;

namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy
{
    public abstract class ChallengeFulfillmentStrategy
    {
        public int Id { get; private set; }
        public string CodeSnippetId { get; private set; }

        protected ChallengeFulfillmentStrategy() {}
        protected ChallengeFulfillmentStrategy(int id, string codeSnippetId): this()
        {
            Id = id;
            CodeSnippetId = codeSnippetId;
        }

        public HintDirectory EvaluateSubmission(CaDETProject solutionAttempt)
        {
            var hints = new HintDirectory();
            if (CodeSnippetId == null)
            {
                solutionAttempt.Classes.ForEach(c => hints.MergeHints(EvaluateClass(c)));
            }
            else if (!CodeSnippetId.Contains("("))
            {
                var targetClass = solutionAttempt.Classes.Find(c => c.FullName.Equals(CodeSnippetId));
                if (targetClass == null) throw new InvalidOperationException($"Solution attempt is missing class {CodeSnippetId}");
                hints.MergeHints(EvaluateClass(targetClass));
            }
            else
            {
                var members = solutionAttempt.Classes.SelectMany(c => c.Members);
                var targetMember = members.First(m => m.Signature().Equals(CodeSnippetId));
                if(targetMember == null) throw new InvalidOperationException($"Solution attempt is missing method {CodeSnippetId}");
                hints.MergeHints(EvaluateMember(targetMember));
            }
            return hints;
        }
        protected abstract HintDirectory EvaluateClass(CaDETClass solutionAttempt);
        protected abstract HintDirectory EvaluateMember(CaDETMember solutionAttempt);
    }
}
