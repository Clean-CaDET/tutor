using System.Collections.Generic;

namespace Tutor.Infrastructure.Database.DataImport.DomainExcelModel
{
    public class DomainExcelContent
    {
        public List<UnitColumns> Units { get; }
        public List<KCColumns> KnowledgeComponents { get; }
        public List<IEColumns> InstructionalEvents { get; }
        public List<AEColumns> AssessmentEvents { get; }
        public DomainExcelContent(List<UnitColumns> units, List<KCColumns> kcs, List<IEColumns> ies, List<AEColumns> aes)
        {
            Units = units;
            KnowledgeComponents = kcs;
            InstructionalEvents = ies;
            AssessmentEvents = aes;
        }
    }
}
