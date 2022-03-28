﻿using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.InstructionalEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IKCService
    {
        Result<List<Unit>> GetUnits();

        Result<Unit> GetUnit(int id, int learnerId);

        Result<KnowledgeComponent> GetKnowledgeComponentById(int id);

        Result<List<AssessmentEvent>> GetAssessmentEventsByKnowledgeComponent(int id);

        Result<List<InstructionalEvent>> GetInstructionalEventsByKnowledgeComponent(int id);

        Result<AssessmentEvent> SelectSuitableAssessmentEvent(int knowledgeComponentId, int learnerId);

        Result<KnowledgeComponentStatistics> GetKnowledgeComponentStatistics(int learnerId, int knowledgeComponentId);

        Result LaunchSession(int learnerId, int knowledgeComponentId);

        Result TerminateSession(int learnerId, int knowledgeComponentId);

        Result AbandonSession(int learnerId, int knowledgeComponentId);
    }
}