using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tutor.Infrastructure.Database.DataImport.LearnerExcelModel;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Infrastructure.Database.DataImport
{
    internal static class LearnerExcelImporter
    {
        internal static List<LearnerGroupsColumns> Import(string sourceFolder)
        {
            var sheets = GetWorksheets(GetExcelDocuments(sourceFolder));
            return Process(sheets);
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

        private static List<LearnerGroupsColumns> Process(List<ExcelWorksheet> sheets)
        {
            var startingId = -1000;
            var groups = new List<LearnerGroupsColumns>();
            foreach (var sheet in sheets)
            {
                var learners = new List<UserLearnerColumns>();
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells["B" + row].Text)) break;
                    var index = ExtractIndex(sheet.Cells["B" + row].Text);
                    var salt = PasswordUtilities.GenerateSalt();
                    learners.Add(new UserLearnerColumns
                    {
                        Id = startingId++,
                        Index = index,
                        Name = sheet.Cells["E" + row].Text,
                        Surname = sheet.Cells["D" + row].Text,
                        Salt = Convert.ToBase64String(salt),
                        Password = PasswordUtilities.HashPassword(sheet.Cells["G" + row].Text, salt)
                    });
                }

                groups.Add(new LearnerGroupsColumns
                {
                    Id = startingId++,
                    GroupName = sheet.Cells["H1"].Text,
                    Learners = learners
                });
            }

            return groups;
        }

        private static string ExtractIndex(string text)
        {
            var program = text.Split()[0];
            var parts = text.Split()[1].Split('/');

            return program + "-" + parts[0] + "-" + parts[1];
        }
    }
}