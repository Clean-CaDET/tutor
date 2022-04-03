using System;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tutor.Infrastructure.Security.Authorization;

namespace Tutor.Infrastructure.Database.DataImport
{
    internal static class LearnerExcelImporter
    {
        internal static List<LearnerColumns> Import(string sourceFolder, string passwordSeed)
        {
            var sheets = GetWorksheets(GetExcelDocuments(sourceFolder));
            return Process(sheets, passwordSeed);
        }
        
        private static IEnumerable<ExcelPackage> GetExcelDocuments(string sourceFolder)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var files = Directory.GetFiles(sourceFolder, "*.xlsx", SearchOption.AllDirectories);
            return files.Select(path => new ExcelPackage(new FileInfo(path)));
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

        private static List<LearnerColumns> Process(List<ExcelWorksheet> sheets, string passwordSeed)
        {
            var learners = new List<LearnerColumns>();
            var startingId = -1000;

            foreach (var sheet in sheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells["B" + row].Text)) break;
                    var index = ExtractIndex(sheet.Cells["B" + row].Text);
                    var salt = PasswordUtilities.GenerateSalt();
                    learners.Add(new LearnerColumns
                    {
                        Id = startingId++,
                        StudentIndex = index,
                        Name = sheet.Cells["E" + row].Text,
                        Surname = sheet.Cells["D" + row].Text,
                        Salt = Convert.ToBase64String(salt),
                        Password = PasswordUtilities.HashPassword(passwordSeed, salt)
                    });
                }
            }

            return learners;
        }

        private static string ExtractIndex(string text)
        {
            var program = text.Split()[0];
            var parts = text.Split()[1].Split('/');

            return program + "-" + parts[0] + "-" + parts[1];
        }
    }
}