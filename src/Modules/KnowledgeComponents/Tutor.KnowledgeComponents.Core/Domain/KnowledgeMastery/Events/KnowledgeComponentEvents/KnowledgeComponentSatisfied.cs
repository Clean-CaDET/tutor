﻿namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;

public class KnowledgeComponentSatisfied : KnowledgeComponentEvent
{
    public double MinutesToSatisfaction { get; set; }
}