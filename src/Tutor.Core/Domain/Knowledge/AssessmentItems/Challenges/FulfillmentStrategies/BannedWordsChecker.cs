using System;
using System.Collections.Generic;
using System.Linq;
using CodeModel.CaDETModel.CodeItems;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges.FulfillmentStrategies
{
    public class BannedWordsChecker : ChallengeFulfillmentStrategy
    {
        public List<string> BannedWords { get; private set; }
        public ChallengeHint Hint { get; private set; }

        private BannedWordsChecker() { }
        public BannedWordsChecker(List<string> bannedWords, ChallengeHint hint, string codeSnippetId) : base(0, codeSnippetId)
        {
            BannedWords = bannedWords;
            Hint = hint;
        }

        private HintDirectory EvaluateClass(CaDETClass solutionAttempt)
        {
            var usedNames = WordExtractor.GetClassNames(solutionAttempt);
            var hints = EvaluateBannedWords(usedNames, solutionAttempt.FullName);
            solutionAttempt.Members.ForEach(m => hints.MergeHints(EvaluateMember(m)));
            return hints;
        }

        protected override HintDirectory EvaluateMember(CaDETMember solutionAttempt)
        {
            var usedNames = WordExtractor.GetMemberNames(solutionAttempt);
            return EvaluateBannedWords(usedNames, solutionAttempt.Signature());
        }

        private HintDirectory EvaluateBannedWords(List<string> usedNames, string codeSnippetId)
        {
            if (BannedWords == null || BannedWords.Count == 0) return null;

            var hints = new HintDirectory();
            if (ContainsBannedWords(usedNames)) hints.AddHint(codeSnippetId, Hint);
            return hints;
        }

        private bool ContainsBannedWords(List<string> names)
        {
            return names.SelectMany(WordExtractor.GetWordsFromName).Any(word => BannedWords.Contains(word, StringComparer.OrdinalIgnoreCase));
        }

        protected override HintDirectory EvaluateClassesAndMembers(List<CaDETClass> solutionAttempt)
        {
            var hints = new HintDirectory();
            foreach (var c in solutionAttempt)
            {
                hints.MergeHints(EvaluateClass(c));
                c.Members.ForEach(m => hints.MergeHints(EvaluateMember(m)));
            }

            return hints;
        }
    }
}
