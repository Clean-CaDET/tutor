using Tutor.Core.ContentModel.LearningObjects;

namespace Tutor.Core.DomainModel.InstructionalEvents
{
    public class Video : LearningObject
    {
        public string Url { get; private set; }

        public Video(int id, int learningObjectSummaryId, string url) : base(id, learningObjectSummaryId)
        {
            Url = url;
        }
    }
}