using System.Threading.Tasks;
using Tutor.Core.LearnerModel.Learners;

namespace Tutor.Web.IAM
{
    public interface IAuthProvider
    {
        Task<Learner> Register(Learner learner);
    }
}