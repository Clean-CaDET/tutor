using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Core.DomainModel.Feedback
{
    public interface IFeedbackRepository
    { 
        void SaveEmotionsFeedback (EmotionsFeedback emotionsFeedback);
    }
}
