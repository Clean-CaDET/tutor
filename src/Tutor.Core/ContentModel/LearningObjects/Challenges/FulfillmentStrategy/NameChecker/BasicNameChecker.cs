using CodeModel.CaDETModel.CodeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tutor.Core.ContentModel.LearningObjects.Challenges.FulfillmentStrategy.NameChecker
{
    public class BasicNameChecker : ChallengeFulfillmentStrategy
    {
        //TODO: Delegate to several rule types as our understanding grows - e.g., NameLengthRule, RequiredWordRule. For now we are going with the simplest solution.
        //TODO: Currently this checker should either define (some subset of) banned OR required words and make a related hint.
        public List<string> BannedWords { get; private set; }
        public List<string> RequiredWords { get; private set; }
        public ChallengeHint Hint { get; private set; }
        public List<string> PossibleRenames { get; private set; }

        private BasicNameChecker() {}
        public BasicNameChecker(List<string> bannedWords, List<string> requiredWords, ChallengeHint hint, string codeSnippetId, List<string> possibleRenames): this()
        {
            BannedWords = bannedWords;
            RequiredWords = requiredWords;
            Hint = hint;
            CodeSnippedId = codeSnippetId;
            PossibleRenames = possibleRenames;
        }

        public override HintDirectory EvaluateSubmission(List<CaDETClass> solutionAttempt)
        {
            var usedNames = GetUsedNames(solutionAttempt);
            return EvaluateNames(usedNames);
        }

        private List<string> GetUsedNames(List<CaDETClass> solutionAttempt)
        {
            var caDETClass = solutionAttempt.Find(c => c.FullName == CodeSnippedId);
            if (caDETClass != null)
                return GetClassNames(caDETClass);
            
            var caDETMember = solutionAttempt.SelectMany(c => c.Members).FirstOrDefault(m => m.Signature() == CodeSnippedId);
            if (caDETMember != null)
                return GetMemberNames(caDETMember);

            foreach (var name in PossibleRenames)
            {
                caDETClass = solutionAttempt.Find(c => c.FullName == name);
                if (caDETClass != null)
                    return GetClassNames(caDETClass);
                caDETMember = solutionAttempt.SelectMany(c => c.Members).FirstOrDefault(m => m.Signature() == name);
                if (caDETMember != null)
                    return GetMemberNames(caDETMember);
            }

            throw new Exception($"Solution attempt is missing class/method {CodeSnippedId}");
        }

        private List<string> GetClassNames(CaDETClass caDETClass)
        {
            var names = new List<string> { caDETClass.Name };
            names.AddRange(caDETClass.Fields.Select(f => f.Name));
            names.AddRange(caDETClass.Members.Select(m => m.Name));
            return names;
        }

        private List<string> GetMemberNames(CaDETMember member)
        {
            var memberNames = new List<string> { member.Name };
            memberNames.AddRange(member.Variables.Select(v => v.Name));
            memberNames.AddRange(member.Params.Select(p => p.Name));
            return memberNames;
        }

        private HintDirectory EvaluateNames(List<string> namesUsedInCodeSnippet)
        {
            var hints = new HintDirectory();
            hints.MergeHints(EvaluateBannedWords(namesUsedInCodeSnippet));
            hints.MergeHints(EvaluateRequiredWords(namesUsedInCodeSnippet));
            return hints;
        }

        private HintDirectory EvaluateBannedWords(List<string> usedNames)
        {
            if (BannedWords == null || BannedWords.Count == 0) return null;

            var hints = new HintDirectory();
            if (ContainsBannedName(usedNames))
                hints.AddHint(CodeSnippedId, Hint);

            return hints;
        }

        private bool ContainsBannedName(List<string> names)
        {
            foreach (var word in names.SelectMany(GetWordsFromName))
            {
                if (BannedWords.Contains(word, StringComparer.OrdinalIgnoreCase)) return true;
            }

            return false;
        }

        private HintDirectory EvaluateRequiredWords(List<string> usedNames)
        {
            if (RequiredWords == null || RequiredWords.Count == 0) return null;
            
            var allWords = usedNames.SelectMany(GetWordsFromName).ToList();
            if (RequiredWords.All(req => allWords.Contains(req, StringComparer.OrdinalIgnoreCase))) return null;

            var hints = new HintDirectory();
            hints.AddHint("ALL", Hint);
            return hints;
        }

        private string[] GetWordsFromName(string name)
        {
            var words = Regex.Split(name, "[A-Z]");

            var matches = Regex.Matches(name, "[A-Z]");
            for (int i = 0; i < words.Length - 1; i++)
            {
                words[i + 1] = matches[i] + words[i + 1];
            }

            var singleWords = words.Where(val => val != "").ToArray();
            var allWords = GetSyntagmFromName(name, singleWords);
            allWords.AddRange(singleWords);
            return allWords.Distinct().ToArray();
        }

        private List<string> GetSyntagmFromName(string name, string[] words)
        {
            List<string> syntagms = new List<string>();
            int startLength = 0;
            for (var i = 0; i <= words.Length - 2; i++)
            {
                int endLength = words[i].Length;
                for (var j = i + 1; j <= words.Length - 1; j++)
                {
                    endLength += words[j].Length;
                    syntagms.Add(name.Substring(startLength, endLength));
                }
                startLength += words[i].Length;
            }
            return syntagms;
        }

        public override List<ChallengeHint> GetAllHints()
        {
            return new() { Hint };
        }
    }
}
