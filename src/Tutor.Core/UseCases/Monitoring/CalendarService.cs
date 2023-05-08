using System;
using System.Collections.Generic;
using System.Linq;
using FluentResults;
using Tutor.Core.Domain.KnowledgeMastery.Events.SessionLifecycleEvents;
using Tutor.Core.Domain.Session;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Monitoring;

public class CalendarService : ICalendarService
{
    private readonly ISessionDatabaseRepository _sessionDatabaseRepository;
    private readonly ILearnerRepository _learnerRepository;
    
    public CalendarService(ISessionDatabaseRepository sessionDatabaseRepository, ILearnerRepository learnerRepository)
    {
        _sessionDatabaseRepository = sessionDatabaseRepository;
        _learnerRepository = learnerRepository;
    }
    
    public Result<List<Session>> GetSessions(int learnerId)
    {
        IEnumerable<SessionLaunched> sessionLaunchedEvents = _sessionDatabaseRepository.GetSessionLaunchedEvents(learnerId).OrderBy(e => e.TimeStamp);
        var sessionLaunchedAndFinishedEvents = InitSessions(learnerId, sessionLaunchedEvents);
        var mergedSessions = MergeSessions(sessionLaunchedAndFinishedEvents);
        
        foreach (var session in mergedSessions)
        {
            var events =
                _sessionDatabaseRepository.GetEventsForSession(learnerId, session.Start, session.End);
            session.Events = events.OrderBy(e => e.TimeStamp).ToList();
        }
        return Result.Ok(mergedSessions);
    }

    public Result<Learner> GetLearner(int learnerId)
    {
        return _learnerRepository.GetById(learnerId);
    }

    private List<Session> InitSessions(int learnerId, IEnumerable<SessionLaunched> launchedSessionEvents)
    {
        var sessions = new List<Session>();
        foreach (var launchedSessionEvent in launchedSessionEvents)
        {
            var sessionFinishedEvent = _sessionDatabaseRepository.GetSessionFinishedEvent(learnerId, launchedSessionEvent);
            if (sessionFinishedEvent == null) continue;
            var newSession = new Session
            {
                Start = launchedSessionEvent.TimeStamp,
                End = sessionFinishedEvent.TimeStamp
            };
            sessions.Add(newSession);
        }
        return sessions;
    }

    private List<Session> MergeSessions(List<Session> sessions)
    {
        var mergedSessions = new List<Session>();
        var merging = false;
        var start = new DateTime();
        var end = new DateTime();
        
        for (var i = 0; i < sessions.Count; i++)
        {
            if (!merging)
            {
                start = sessions[i].Start;
                end = sessions[i].End;
            }

            if (i == sessions.Count - 1)
            {
                end = sessions[i].End;
                var mergedSession = new Session
                {
                    Start = start,
                    End = end
                };
                mergedSessions.Add(mergedSession);
                break;
            }

            if (sessions[i + 1].Start.Subtract(sessions[i].End).TotalMinutes < 10)
            {
                merging = true;
                end = sessions[i + 1].End;
            }
            else
            {
                merging = false;
                var mergedSession = new Session
                { 
                    Start = start,
                    End = end
                };
                mergedSessions.Add(mergedSession);
            }
        }
        return mergedSessions;
    }
}