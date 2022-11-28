using Shouldly;
using System.IO;
using Tutor.Infrastructure.Database.DataImport;
using Xunit;

namespace Tutor.Infrastructure.Tests.Integration.DataImport;

public class ExcelToSqlTransformerTests
{
    [Fact]
    public void Can_transform_to_sql()
    {
        const string sourceFolder = "C:/TUTOR-EDU/FTN/Add-RP-VAR/domain";
        const string learnerFolder = "C:/TUTOR-EDU/FTN/Add-RP-VAR/learner3";
        const string enrollmentFolder = "C:/TUTOR-EDU/FTN/Add-RP-VAR/enrollment";
        const string destinationFile = "C:/TUTOR-EDU/FTN/output-RP-VAR-3.sql";

        ExcelToSqlTransformer.TransformUnitIncrement(sourceFolder, learnerFolder, enrollmentFolder, destinationFile);

        File.Exists(destinationFile).ShouldBeTrue();
    }
}