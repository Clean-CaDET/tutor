using System;
using System.Collections.Generic;
using System.Linq;
using CodeModel.CaDETModel;
using CodeModel.CaDETModel.CodeItems;

namespace Tutor.Core.DomainModel.AssessmentItems.Challenges
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
                hints.MergeHints(EvaluateClassesAndMembers(solutionAttempt.Classes));
            }
            else if (!CodeSnippetId.Contains('('))
            {
                var targetClass = solutionAttempt.Classes.Find(c => c.FullName.Equals(CodeSnippetId));
                if (targetClass == null) throw new InvalidOperationException($"Solution attempt is missing class {CodeSnippetId}");
                hints.MergeHints(EvaluateClassesAndMembers(new List<CaDETClass> { targetClass }));
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

        protected abstract HintDirectory EvaluateClassesAndMembers(List<CaDETClass> solutionAttempt);

        protected abstract HintDirectory EvaluateMember(CaDETMember solutionAttempt);
    }
}
