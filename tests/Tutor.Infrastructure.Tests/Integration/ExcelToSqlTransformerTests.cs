using Shouldly;
using System.IO;
using Tutor.Infrastructure.Database.DataImport;
using Xunit;

namespace Tutor.Infrastructure.Tests.Integration
{
    public class ExcelToSqlTransformerTests
    {
        [Fact]
        public void Can_transform_to_sql()
        {
            const string sourceFolder = "C:/temp/tutor-excel-data/all-domain";
            const string learnerFolder = "C:/temp/tutor-excel-data/learner";
            const string destinationFile = "C:/temp/tutor-excel-data/output-v1.sql";

            ExcelToSqlTransformer.Transform(sourceFolder, learnerFolder, destinationFile);

            File.Exists(destinationFile).ShouldBeTrue();
        }
    }
}
