using System.Collections.Generic;
using FluentResults;
using Tutor.Core.Domain.Session;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Monitoring;

public interface ICalendarService
{
    Result<List<Session>> GetSessions(int learnerId);

    Result<Learner> GetLearner(int learnerId);
}