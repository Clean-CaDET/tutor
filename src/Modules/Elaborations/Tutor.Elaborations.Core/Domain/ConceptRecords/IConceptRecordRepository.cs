using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Elaborations.Core.Domain.ConceptRecords;

public interface IConceptRecordRepository : ICrudRepository<ConceptRecord>
{
    List<ConceptRecord> GetByCourse(int courseId);
}
