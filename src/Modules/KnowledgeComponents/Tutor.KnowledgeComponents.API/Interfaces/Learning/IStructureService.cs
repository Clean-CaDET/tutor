﻿using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge;

namespace Tutor.KnowledgeComponents.API.Interfaces.Learning;

public interface IStructureService
{
    Result<List<int>> GetMasteredUnitIds(List<int> unitIds, int learnerId);
    Result<List<KcWithMasteryDto>> GetKcsWithMasteries(int unitId, int learnerId);
    Result<KnowledgeComponentDto> GetKnowledgeComponent(int kcId, int learnerId);
}