using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Learning;
using Tutor.Courses.Core.Domain;
using Tutor.KnowledgeComponents.API.Internal;
using Tutor.LearningTasks.API.Internal;

namespace Tutor.Courses.Core.UseCases.Learning;

public class UnitProgressService : IUnitProgressService
{
    private readonly IKnowledgeMasteryQuerier _kcMasteryQuerier;
    private readonly ITaskProgressQuerier _taskProgressQuerier;

    public UnitProgressService(IKnowledgeMasteryQuerier kcMasteryQuerier, ITaskProgressQuerier taskProgressQuerier)
    {
        _kcMasteryQuerier = kcMasteryQuerier;
        _taskProgressQuerier = taskProgressQuerier;
    }

    public Result<List<int>> GetMasteredUnitIds(List<int> unitIds, int learnerId)
    {
        var masteredKcUnits = _kcMasteryQuerier.GetMasteredUnitIds(unitIds, learnerId).Value;
        var completedTaskUnits = _taskProgressQuerier.GetCompletedUnitIds(unitIds, learnerId).Value;

        return masteredKcUnits.Intersect(completedTaskUnits).ToList();
    }
}