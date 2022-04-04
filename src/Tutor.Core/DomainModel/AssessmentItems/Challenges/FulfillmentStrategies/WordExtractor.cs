using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CodeModel.CaDETModel.CodeItems;

namespace Tutor.Core.DomainModel.AssessmentItems.Challenges.FulfillmentStrategies
{
    internal static class WordExtractor
    {
        internal static string[] GetWordsFromName(string name)
        {
            var words = Regex.Split(name, "[A-Z]");

            var matches = Regex.Matches(name, "[A-Z]");
            for (var i = 0; i < words.Length - 1; i++)
            {
                words[i + 1] = matches[i] + words[i + 1];
            }

            var singleWords = words.Where(val => val != "").ToArray();
            var allWords = GetSyntagmFromName(name, singleWords);
            allWords.AddRange(singleWords);
            return allWords.Distinct().ToArray();
        }

        internal static List<string> GetClassNames(CaDETClass cadetClass)
        {
            var names = new List<string> { cadetClass.Name };
            names.AddRange(cadetClass.Fields.Select(f => f.Name));
            names.AddRange(cadetClass.Members.Select(m => m.Name));
            return names;
        }

        internal static List<string> GetMemberNames(CaDETMember member)
        {
            var memberNames = new List<string> { member.Name };
            memberNames.AddRange(member.Variables.Select(v => v.Name));
            memberNames.AddRange(member.Params.Select(p => p.Name));
            return memberNames;
        }

        private static List<string> GetSyntagmFromName(string name, string[] words)
        {
            var syntagms = new List<string>();
            var startLength = 0;
            for (var i = 0; i <= words.Length - 2; i++)
            {
                var endLength = words[i].Length;
                for (var j = i + 1; j <= words.Length - 1; j++)
                {
                    endLength += words[j].Length;
                    syntagms.Add(name.Substring(startLength, endLength));
                }
                startLength += words[i].Length;
            }
            return syntagms;
        }
    }
}