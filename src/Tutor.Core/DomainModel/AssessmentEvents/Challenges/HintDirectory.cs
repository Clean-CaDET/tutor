﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges
{
    public class HintDirectory
    {
        private readonly Dictionary<ChallengeHint, List<string>> _directory;

        public HintDirectory()
        {
            _directory = new Dictionary<ChallengeHint, List<string>>();
        }

        public Dictionary<ChallengeHint, List<string>> GetDirectory()
        {
            return new(_directory);
        }

        public List<ChallengeHint> GetHints()
        {
            return _directory.Keys.ToList();
        }

        public void AddHint(string codeSnippetId, ChallengeHint hint)
        {
            if(hint == null) throw new InvalidOperationException("Hint cannot be null.");
            if (_directory.ContainsKey(hint))
            {
                if (!_directory[hint].Contains(codeSnippetId))
                {
                    _directory[hint].Add(codeSnippetId);
                }
            }
            else
            {
                _directory[hint] = new List<string> { codeSnippetId };
            }
        }

        public void AddHints(ChallengeHint hint, List<string> codeSnippetIds)
        {
            codeSnippetIds.ForEach(codeSnippetId => AddHint(codeSnippetId, hint));
        }

        public void MergeHints(HintDirectory other)
        {
            if (other == null) return;
            foreach (var hint in other._directory.Keys)
            {
                AddHints(hint, other._directory[hint]);
            }
        }

        public bool IsEmpty()
        {
            return _directory.Count == 0;
        }

        public void AddAllHints(List<ChallengeHint> allHints)
        {
            foreach (var hint in allHints.Where(hint => !_directory.ContainsKey(hint)))
            {
                _directory.Add(hint, new List<string> {"ALL"});
            }
        }
    }
}
