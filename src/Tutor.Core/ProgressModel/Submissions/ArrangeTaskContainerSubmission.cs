using System.Collections.Generic;

namespace Tutor.Core.ProgressModel.Submissions
{
    public class ArrangeTaskContainerSubmission
    {
        public int Id { get; private set; }
        public int ContainerId { get; private set; }
        public List<int> ElementIds { get; private set; }

        private ArrangeTaskContainerSubmission() {}
        public ArrangeTaskContainerSubmission(int id, int containerId, List<int> elementIds): this()
        {
            Id = id;
            ContainerId = containerId;
            ElementIds = elementIds;
        }
    }
}