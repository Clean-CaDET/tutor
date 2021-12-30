﻿using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.InstructionalEvents;
using Tutor.Core.LearnerModel.Learners;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IKCRepository
    {
        List<Unit> GetUnits();
        
        Unit GetUnit(int id, int learnerId);

        KnowledgeComponent GetKnowledgeComponent(int id);

        List<AssessmentEvent> GetAssessmentEventsByKnowledgeComponent(int id);

        List<InstructionalEvent> GetInstructionalEventsByKnowledgeComponent(int id);
        
        List<AssessmentEvent> GetAssessmentEventsByKnowledgeComponentAndLearner(int knowledgeComponentId, int learnerId);
        
        KnowledgeComponentMastery GetKnowledgeComponentMastery(int learnerId, int knowledgeComponentId);
        
        void UpdateKCMastery(KnowledgeComponentMastery kcMastery);
    }
}