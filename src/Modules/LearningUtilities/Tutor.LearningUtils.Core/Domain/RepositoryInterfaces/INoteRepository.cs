namespace Tutor.LearningUtils.Core.Domain.RepositoryInterfaces;

public interface INoteRepository
{
    List<Note> GetNotesByLearnerAndUnit(int learnerId, int unitId);
}