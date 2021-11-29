using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks
{
    public class ArrangeTaskContainer
    {
        public int Id { get; private set; }
        public int ArrangeTaskId { get; private set; }
        public string Title { get; private set; }
        public List<ArrangeTaskElement> Elements { get; private set; }

        public bool IsCorrectSubmission(List<int> elementIds)
        {
            return elementIds.Count == Elements.Count
                   && Elements.Select(e => e.Id).All(elementIds.Contains);
        }
    }
}