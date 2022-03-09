using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Core.DomainModel.Feedback
{
    public class EmotionsFeedback
    {
        public int Id { get; private set; }
        public int LearnerId { get; private set; }
        public int KnowledgeComponentId { get; private set; }
        public string Comment { get; private set; }
        public DateTime TimeStamp { get; private set; } = DateTime.Now.ToUniversalTime();
    }
}
