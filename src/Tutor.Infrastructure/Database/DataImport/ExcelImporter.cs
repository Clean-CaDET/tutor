using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tutor.Infrastructure.Database.DataImport;

public static class ExcelImporter
{
    public static List<ExcelWorksheet> ImportWorkSheets(string sourceFolder)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var files = Directory.GetFiles(sourceFolder, "*.xlsx", SearchOption.AllDirectories);
        var packages = files.Select(path => new ExcelPackage(new FileInfo(path)));

        return GetWorksheets(packages);
    }

    private static List<ExcelWorksheet> GetWorksheets(IEnumerable<ExcelPackage> documents)
    {
        var sheets = new List<ExcelWorksheet>();
        foreach (var document in documents)
        {
            sheets.AddRange(document.Workbook.Worksheets);
        }

        return sheets;
    }
}