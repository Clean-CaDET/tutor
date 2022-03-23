using CodeModel.CaDETModel.CodeItems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.NameChecker
{
    public class RequiredWordsChecker : ChallengeFulfillmentStrategy
    {
        public List<string> RequiredWords { get; private set; }
        public ChallengeHint Hint { get; private set; }

        private RequiredWordsChecker() {}
        public RequiredWordsChecker(List<string> requiredWords, ChallengeHint hint, string codeSnippetId): base(0, codeSnippetId)
        {
            RequiredWords = requiredWords;
            Hint = hint;
        }

        protected override HintDirectory EvaluateClassesAndMembers(List<CaDETClass> solutionAttempt)
        {
            var allNames = solutionAttempt.SelectMany(GetAllNames);
            return EvaluateRequiredWords(allNames, "ALL");
        }

        private static List<string> GetAllNames(CaDETClass solutionAttempt)
        {
            var allNames = WordExtractor.GetClassNames(solutionAttempt);
            allNames.AddRange(solutionAttempt.Members.SelectMany(WordExtractor.GetMemberNames));
            return allNames;
        }

        protected override HintDirectory EvaluateMember(CaDETMember solutionAttempt)
        {
            return EvaluateRequiredWords(WordExtractor.GetMemberNames(solutionAttempt), solutionAttempt.Signature());
        }

        private HintDirectory EvaluateRequiredWords(IEnumerable<string> usedNames, string codeSnippetId)
        {
            if (RequiredWords == null || RequiredWords.Count == 0) return null;
            
            var allWords = usedNames.SelectMany(WordExtractor.GetWordsFromName).ToList();
            if (RequiredWords.All(req => allWords.Contains(req, StringComparer.OrdinalIgnoreCase))) return null;

            var hints = new HintDirectory();
            hints.AddHint(codeSnippetId, Hint);
            return hints;
        }
    }
}
