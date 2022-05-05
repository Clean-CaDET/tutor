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
            const string sourceFolder = "C:/temp/tutor-excel-data/domain-2";
            const string learnerFolder = "C:/temp/tutor-excel-data/learner-ftn-of";
            const string destinationFile = "C:/temp/tutor-excel-data/output-v100.sql";

            ExcelToSqlTransformer.Transform(sourceFolder, learnerFolder, destinationFile);

            File.Exists(destinationFile).ShouldBeTrue();
        }
    }
}
