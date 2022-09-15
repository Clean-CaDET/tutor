using System.Collections.Generic;
using FluentResults;
using Tutor.Core.LearnerModel.DomainOverlay.EnrollmentModel;

namespace Tutor.Core.LearnerModel
{
    public interface ILearnerService
    {
        Result<Learner> GetLearnerProfile(int id);
        Result<List<LearnerGroup>> GetGroups();
    }
}