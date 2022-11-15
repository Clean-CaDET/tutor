﻿using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.KnowledgeMastery.Events;
using Tutor.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;

namespace Tutor.Core.UseCases.KnowledgeAnalysis
{
    public class UnitAnalysisService : IUnitAnalysisService
    {
        private readonly IKnowledgeRepository _knowledgeRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IEventStore _eventStore;

        public UnitAnalysisService(IKnowledgeRepository kcRepository, IGroupRepository groupRepository, IEventStore eventStore)
        {
            _knowledgeRepository = kcRepository;
            _groupRepository = groupRepository;
            _eventStore = eventStore;
        }

        public Result<List<KcStatistics>> GetKnowledgeComponentsStats(int unitId, int instructorId)
        {
            //Check if instructor owns the course

            var kcs = _knowledgeRepository.GetKnowledgeComponentsForUnit(unitId);
            var kcIds = kcs.Select(kc => kc.Id).ToList();

            var eventQuery =
                _eventStore.Events.Where(e => kcIds.Contains(e.RootElement.GetProperty("KnowledgeComponentId").GetInt32()));
            var events = eventQuery.ToList<KnowledgeComponentEvent>();

            var enrolledLearnersCount = _groupRepository.CountAllEnrollmentsInUnit(unitId);
            
            return CalculateKcStatistics(kcs, events, enrolledLearnersCount);
        }

        public Result<List<KcStatistics>> GetKnowledgeComponentsStatsForGroup(int unitId, int groupId, int instructorId)
        {
            var learnerIds = _groupRepository.GetLearnersInGroup(groupId).Select(l => l.Id).ToList();

            var kcs = _knowledgeRepository.GetKnowledgeComponentsForUnit(unitId);
            var kcIds = kcs.Select(kc => kc.Id).ToList();

            var events = _eventStore.Events
                .Where(e => kcIds.Contains(e.RootElement.GetProperty("KnowledgeComponentId").GetInt32()))
                .Where(e => learnerIds.Contains(e.RootElement.GetProperty("LearnerId").GetInt32()))
                .ToList<KnowledgeComponentEvent>();

            return CalculateKcStatistics(kcs, events, learnerIds.Count);
        }

        private static List<KcStatistics> CalculateKcStatistics(List<KnowledgeComponent> kcs, List<KnowledgeComponentEvent> events, int enrolledLearnersCount)
        {
            return kcs.Select(kc =>
            {
                var kcEvents = events.Where(e => e.KnowledgeComponentId == kc.Id).ToList();
                var startedEvents = kcEvents.Where(e => e is KnowledgeComponentStarted).ToList();
                var completedEvents = kcEvents.Where(e => e is KnowledgeComponentCompleted).ToList();
                var passedEvents = kcEvents.Where(e => e is KnowledgeComponentPassed).ToList();

                return new KcStatistics
                {
                    KcCode = kc.Code,
                    KcName = kc.Name,
                    TotalRegistered = enrolledLearnersCount,
                    TotalStarted = startedEvents.Count,
                    TotalCompleted = completedEvents.Count,
                    TotalPassed = passedEvents.Count,
                    MinutesToCompletion = CalculateMinutesBetweenEvents(startedEvents, completedEvents),
                    MinutesToPass = CalculateMinutesBetweenEvents(startedEvents, passedEvents)
                };
            }).ToList();
        }

        private static List<int> CalculateMinutesBetweenEvents(List<KnowledgeComponentEvent> startEvents, List<KnowledgeComponentEvent> endEvents)
        {
            var result = new List<int>();
            foreach (var endEvent in endEvents)
            {
                var matchingStartEvent = startEvents.Find(e => e.LearnerId == endEvent.LearnerId);
                if (matchingStartEvent == null) throw new InvalidOperationException();

                var minuteDifference = (endEvent.TimeStamp - matchingStartEvent.TimeStamp).TotalMinutes;
                result.Add((int)minuteDifference);
            }
            return result;
        }
    }
}
