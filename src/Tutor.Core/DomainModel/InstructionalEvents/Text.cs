using Tutor.Core.ContentModel.LearningObjects;

namespace Tutor.Core.DomainModel.InstructionalEvents
{
    public class Text : LearningObject
    {
        public string Content { get; private set; }

        public Text(int id, int learningObjectSummaryId, string content) : base(id, learningObjectSummaryId)
        {
            Content = content;
        }
    }
}