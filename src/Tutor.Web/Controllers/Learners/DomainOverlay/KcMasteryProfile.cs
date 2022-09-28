﻿using AutoMapper;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.AssessmentItemMasteries;
using Tutor.Web.Controllers.Learners.DomainOverlay.DTOs;

namespace Tutor.Web.Controllers.Learners.DomainOverlay
{
    public class KcMasteryProfile : Profile
    {
        public KcMasteryProfile()
        {
            CreateMap<KnowledgeComponentMastery, KnowledgeComponentMasteryDto>();
            CreateMap<AssessmentItemMastery, AssessmentItemMasteryDto>();
            CreateMap<KcMasteryStatistics, KcMasteryStatisticsDto>();
        }
    }
}