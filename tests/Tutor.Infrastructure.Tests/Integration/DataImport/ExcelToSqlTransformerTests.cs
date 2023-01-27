using Shouldly;
using System.IO;
using Tutor.Infrastructure.DataImport;

namespace Tutor.Infrastructure.Tests.Integration.DataImport;

public class ExcelToSqlTransformerTests
{
    //[Fact]
    public void Can_transform_to_sql()
    {
        const string sourceFolder = "C:/TUTOR-EDU/FTN/Add-RP-IF/domain";
        const string learnerFolder = "C:/TUTOR-EDU/FTN/Add-RP-IF/learner";
        const string enrollmentFolder = "C:/TUTOR-EDU/FTN/Add-RP-IF/enrollment";
        const string destinationFile = "C:/TUTOR-EDU/FTN/output-RP-IF-5.sql";

        ExcelToSqlTransformer.TransformUnitIncrement(sourceFolder, learnerFolder, enrollmentFolder, destinationFile);

        File.Exists(destinationFile).ShouldBeTrue();
    }
}