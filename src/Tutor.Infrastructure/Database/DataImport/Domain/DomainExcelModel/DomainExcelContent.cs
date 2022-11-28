using System.Collections.Generic;

namespace Tutor.Infrastructure.Database.DataImport.Domain.DomainExcelModel;

public class DomainExcelContent
{
    public List<UnitColumns> Units { get; }
    public List<KcColumns> KnowledgeComponents { get; }
    public List<IeColumns> InstructionalItems { get; }
    public List<AeColumns> AssessmentItems { get; }
    public List<CourseColumns> Courses { get; set; }

    public DomainExcelContent(List<CourseColumns> courses, List<UnitColumns> units, List<KcColumns> kcs, List<IeColumns> its, List<AeColumns> aes)
    {
        Courses = courses;
        Units = units;
        KnowledgeComponents = kcs;
        InstructionalItems = its;
        AssessmentItems = aes;
    }
}