﻿using FluentResults;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.Knowledge;

public interface IKnowledgeComponentService
{
    Result<KnowledgeComponent> Get(int id, int instructorId);
    Result<KnowledgeComponent> Create(KnowledgeComponent kc, int instructorId);
    Result<KnowledgeComponent> Update(KnowledgeComponent kc, int instructorId);
    Result Delete(int id, int instructorId);
}