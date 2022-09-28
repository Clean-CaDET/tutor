using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;
using Tutor.Infrastructure.Database.DataImport.Domain.DomainExcelModel;
using static System.Int32;

namespace Tutor.Infrastructure.Database.DataImport.Domain
{
    public static class ExcelToDomainTransformer
    {
        public static DomainExcelContent Transform(List<ExcelWorksheet> sheets)
        {
            var courses = CreateCourses(sheets.Where(s => s.Name == "Courses"));
            var units = CreateUnits(sheets.Where(s => s.Name == "Units"), courses);
            var kcs = CreateKCs(sheets.Where(s => s.Name == "KCs"), units);
            var ies = CreateIEs(sheets.Where(s => s.Name == "IEs"), kcs);
            var aes = CreateAEs(sheets.Where(s => s.Name == "AEs"), kcs);

            return new DomainExcelContent(courses, units, kcs, ies, aes);
        }

        private static List<CourseColumns> CreateCourses(IEnumerable<ExcelWorksheet> courseSheets)
        {
            var courses = new List<CourseColumns>();
            var startingId = -100;

            foreach (var sheet in courseSheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells["A" + row].Text)) break;
                    courses.Add(new CourseColumns
                    {
                        Id = startingId++,
                        Code = sheet.Cells["A" + row].Text,
                        Name = sheet.Cells["B" + row].Text,
                        Description = sheet.Cells["C" + row].Text
                    });
                }
            }

            return courses;
        }

        private static List<UnitColumns> CreateUnits(IEnumerable<ExcelWorksheet> unitSheets, List<CourseColumns> courses)
        {
            var units = new List<UnitColumns>();
            var startingId = -100;

            foreach (var sheet in unitSheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells["A" + row].Text)) break;
                    units.Add(new UnitColumns
                    {
                        Id = startingId++,
                        Code = sheet.Cells["A" + row].Text,
                        Name = sheet.Cells["B" + row].Text,
                        Description = sheet.Cells["C" + row].Text,
                        CourseId = courses.First(c => c.Code.Equals(sheet.Cells["D" + row].Text)).Id
                    });
                }
            }

            return units;
        }

        private static List<KCColumns> CreateKCs(IEnumerable<ExcelWorksheet> kcSheets, List<UnitColumns> units)
        {
            var kcs = new List<KCColumns>();
            var startingId = -100;

            foreach (var sheet in kcSheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells["A" + row].Text)) break;
                    var kc = new KCColumns
                    {
                        Id = startingId++,
                        Code = sheet.Cells["A" + row].Text,
                        Name = sheet.Cells["B" + row].Text,
                        Description = sheet.Cells["C" + row].Text,
                        ExpectedDurationInMinutes = Parse(sheet.Cells["D" + row].Text)
                    };

                    if (!string.IsNullOrEmpty(sheet.Cells["E" + row].Text))
                    {
                        kc.UnitId = units.First(u => u.Code.Equals(sheet.Cells["E" + row].Text)).Id;
                    }

                    if (!string.IsNullOrEmpty(sheet.Cells["F" + row].Text))
                    {
                        kc.ParentId = kcs.First(k => k.Code.Equals(sheet.Cells["F" + row].Text)).Id;
                    }

                    kcs.Add(kc);
                }
            }

            return kcs;
        }

        private static List<IEColumns> CreateIEs(IEnumerable<ExcelWorksheet> ieSheets, List<KCColumns> kcs)
        {
            var ies = new List<IEColumns>();
            var startingId = -1000;

            foreach (var sheet in ieSheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells["B" + row].Text)) break;

                    ies.Add(new IEColumns
                    {
                        Id = startingId++,
                        KnowledgeComponentId = kcs.First(k => k.Code.Equals(sheet.Cells["B" + row].Text)).Id,
                        Type = sheet.Cells["C" + row].Text,
                        Text = sheet.Cells["D" + row].Text,
                        Url = sheet.Cells["E" + row].Text,
                        Caption = sheet.Cells["F" + row].Text,
                        Order = string.IsNullOrEmpty(sheet.Cells["G" + row].Text) ? -1 : Parse(sheet.Cells["G" + row].Text)
                    });
                }
            }

            return ies;
        }

        private static List<AEColumns> CreateAEs(IEnumerable<ExcelWorksheet> aeSheets, List<KCColumns> kcs)
        {
            var aes = new List<AEColumns>();
            var startingId = -1000;

            foreach (var sheet in aeSheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells["B" + row].Text)) break;

                    aes.Add(new AEColumns
                    {
                        Id = startingId++,
                        KnowledgeComponentId = kcs.First(k => k.Code.Equals(sheet.Cells["B" + row].Text)).Id,
                        Type = sheet.Cells["C" + row].Text,
                        Text = sheet.Cells["D" + row].Text,
                        Items = GetAeItems(sheet, row),
                        Order = string.IsNullOrEmpty(sheet.Cells["K" + row].Text) ? -1 : Parse(sheet.Cells["K" + row].Text)
                    });
                }
            }

            return aes;
        }

        private static List<string> GetAeItems(ExcelWorksheet sheet, int row)
        {
            var items = new List<string>();
            var columns = new []{ "E", "F", "G", "H", "I", "J" };

            foreach (var column in columns)
            {
                if (string.IsNullOrEmpty(sheet.Cells[column + row].Text)) break;

                items.Add(sheet.Cells[column + row].Text);
            }

            return items;
        }
    }
}
