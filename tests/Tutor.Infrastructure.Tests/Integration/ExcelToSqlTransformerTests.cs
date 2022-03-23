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
            var sourceFolder = "C:/temp/tutor-excel-data";
            var destinationFile = "C:/temp/tutor-excel-data/output.sql";

            ExcelToSqlTransformer.Transform(sourceFolder, destinationFile);

            File.Exists(destinationFile).ShouldBeTrue();
        }
    }
}
