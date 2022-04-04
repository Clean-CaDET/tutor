using System.Threading.Tasks;
using Tutor.Core.LearnerModel;

namespace Tutor.Web.IAM
{
    public interface IAuthProvider
    {
        Task<Learner> Register(Learner learner);
    }
}