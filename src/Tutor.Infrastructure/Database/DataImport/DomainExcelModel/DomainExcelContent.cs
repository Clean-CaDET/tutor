using System.Collections.Generic;

namespace Tutor.Infrastructure.Database.DataImport.DomainExcelModel
{
    public class DomainExcelContent
    {
        public List<UnitColumns> Units { get; }
        public List<KCColumns> KnowledgeComponents { get; }
        public List<IEColumns> InstructionalItems { get; }
        public List<AEColumns> AssessmentItems { get; }
        public DomainExcelContent(List<UnitColumns> units, List<KCColumns> kcs, List<IEColumns> its, List<AEColumns> aes)
        {
            Units = units;
            KnowledgeComponents = kcs;
            InstructionalItems = its;
            AssessmentItems = aes;
        }
    }
}
