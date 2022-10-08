using FluentResults;
using System.Collections.Generic;
using Tutor.Core.EnrollmentModel;

namespace Tutor.Core.LearnerModel
{
    public interface ILearnerService
    {
        Result<Learner> GetLearnerProfile(int id);
        Result<List<LearnerGroup>> GetGroups();
    }
}