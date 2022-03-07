using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Core.DomainModel.Feedback
{
    public class EmotionsFeedback
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now.ToUniversalTime();
    }
}
