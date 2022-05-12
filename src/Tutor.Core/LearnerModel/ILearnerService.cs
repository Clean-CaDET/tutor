using System.Collections.Generic;
using FluentResults;

namespace Tutor.Core.LearnerModel
{
    public interface ILearnerService
    {
        Result<Learner> GetLearnerProfile(int id);
        Result<List<LearnerGroup>> GetGroups(int instructorId);
    }
}