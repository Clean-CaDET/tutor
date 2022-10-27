using Shouldly;
using System.IO;
using Tutor.Infrastructure.Database.DataImport;
using Xunit;

namespace Tutor.Infrastructure.Tests.Integration.DataImport
{
    public class ExcelToSqlTransformerTests
    {
        [Fact]
        public void Can_transform_to_sql()
        {
            const string sourceFolder = "C:/TUTOR-EDU/FTN/domain";
            const string learnerFolder = "C:/TUTOR-EDU/FTN/learner";
            const string enrollmentFolder = "C:/TUTOR-EDU/FTN/enrollment";
            const string destinationFile = "C:/TUTOR-EDU/FTN/output3.sql";

            ExcelToSqlTransformer.TransformUnitIncrement(sourceFolder, learnerFolder, enrollmentFolder, destinationFile);

            File.Exists(destinationFile).ShouldBeTrue();
        }
    }
}
