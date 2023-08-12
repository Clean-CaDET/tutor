using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.LearningUtils.Core.Domain.RepositoryInterfaces;

public interface INoteRepository : ICrudRepository<Note>
{
    List<Note> GetNotesByLearnerAndUnit(int learnerId, int unitId);
}