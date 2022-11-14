using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;

namespace Tutor.Core.Domain.Stakeholders
{
    public interface ILearnerService
    {
        Result<Learner> GetLearnerProfile(int id);
        Result<List<LearnerGroup>> GetGroups();
    }
}