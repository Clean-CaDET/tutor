using System.Collections.Generic;

namespace Tutor.Infrastructure.Database.DataImport.Domain.DomainExcelModel
{
    public class DomainExcelContent
    {
        public List<UnitColumns> Units { get; }
        public List<KCColumns> KnowledgeComponents { get; }
        public List<IEColumns> InstructionalItems { get; }
        public List<AEColumns> AssessmentItems { get; }
        public List<CourseColumns> Courses { get; set; }

        public DomainExcelContent(List<CourseColumns> courses, List<UnitColumns> units, List<KCColumns> kcs, List<IEColumns> its, List<AEColumns> aes)
        {
            Courses = courses;
            Units = units;
            KnowledgeComponents = kcs;
            InstructionalItems = its;
            AssessmentItems = aes;
        }
    }
}
