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
            const string sourceFolder = "C:/TUTOR-EDU/test-excels/domain";
            const string learnerFolder = "C:/TUTOR-EDU/test-excels/learner";
            const string enrollmentFolder = "C:/TUTOR-EDU/test-excels/enrollment";
            const string destinationFile = "C:/TUTOR-EDU/test-excels/output.sql";

            ExcelToSqlTransformer.Transform(sourceFolder, learnerFolder, enrollmentFolder, destinationFile);

            File.Exists(destinationFile).ShouldBeTrue();
        }
    }
}
