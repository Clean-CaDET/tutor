using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tutor.Infrastructure.Database.DataImport.ColumnModel;

namespace Tutor.Infrastructure.Database.DataImport
{
    public class ExcelToSqlTransformer
    {
        public static void Transform(string sourceFolder, string destinationFile)
        {
            var sheets = GetWorksheets(GetExcelDocuments(sourceFolder));
            var sqlScript = CreateSqlScript(sheets);
            Save(sqlScript, destinationFile);
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

        private static string CreateSqlScript(List<ExcelWorksheet> sheets)
        {
            var units = CreateUnits(sheets.Where(s => s.Name == "Units"));
            var kcs = CreateKCs(sheets.Where(s => s.Name == "KCs"), units);
            var ies = CreateIEs(sheets.Where(s => s.Name == "IEs"), kcs);
            var aes = CreateAEs(sheets.Where(s => s.Name == "AEs"), kcs);

            return BuildSql(units, kcs, ies, aes);
        }
        
        private static List<UnitColumns> CreateUnits(IEnumerable<ExcelWorksheet> unitSheets)
        {
            var units = new List<UnitColumns>();
            var startingId = -1;

            foreach (var sheet in unitSheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells["A" + row].Text)) break;
                    units.Add(new UnitColumns
                    {
                        Id = startingId--,
                        Code = sheet.Cells["A" + row].Text,
                        Name = sheet.Cells["B" + row].Text,
                        Description = sheet.Cells["C" + row].Text
                    });
                }
            }

            return units;
        }

        private static List<KCColumns> CreateKCs(IEnumerable<ExcelWorksheet> kcSheets, List<UnitColumns> units)
        {
            var kcs = new List<KCColumns>();
            var startingId = -1;

            foreach (var sheet in kcSheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells["A" + row].Text)) break;
                    var kc = new KCColumns
                    {
                        Id = startingId--,
                        Code = sheet.Cells["A" + row].Text,
                        Name = sheet.Cells["B" + row].Text,
                        Description = sheet.Cells["C" + row].Text
                    };

                    if (!string.IsNullOrEmpty(sheet.Cells["D" + row].Text))
                    {
                        kc.UnitId = units.First(u => u.Code.Equals(sheet.Cells["D" + row].Text)).Id;
                    }

                    if (!string.IsNullOrEmpty(sheet.Cells["E" + row].Text))
                    {
                        kc.ParentId = kcs.First(k => k.Code.Equals(sheet.Cells["E" + row].Text)).Id;
                    }

                    kcs.Add(kc);
                }
            }

            return kcs;
        }

        private static List<IEColumns> CreateIEs(IEnumerable<ExcelWorksheet> ieSheets, List<KCColumns> kcs)
        {
            var ies = new List<IEColumns>();
            var startingId = -1;

            foreach (var sheet in ieSheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells["B" + row].Text)) break;

                    ies.Add(new IEColumns
                    {
                        Id = startingId--,
                        KnowledgeComponentId = kcs.First(k => k.Code.Equals(sheet.Cells["B" + row].Text)).Id,
                        Type = sheet.Cells["C" + row].Text,
                        Text = sheet.Cells["D" + row].Text,
                        Url = sheet.Cells["E" + row].Text,
                        Caption = sheet.Cells["F" + row].Text
                    });
                }
            }

            return ies;
        }

        private static List<AEColumns> CreateAEs(IEnumerable<ExcelWorksheet> aeSheets, List<KCColumns> kcs)
        {
            var aes = new List<AEColumns>();
            var startingId = -1;

            foreach (var sheet in aeSheets)
            {
                for (var row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrEmpty(sheet.Cells["B" + row].Text)) break;

                    aes.Add(new AEColumns
                    {
                        Id = startingId--,
                        KnowledgeComponentId = kcs.First(k => k.Code.Equals(sheet.Cells["B" + row].Text)).Id,
                        Type = sheet.Cells["C" + row].Text,
                        Text = sheet.Cells["D" + row].Text,
                        Items = GetAeItems(sheet, row)
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

        private static string BuildSql(List<UnitColumns> units, List<KCColumns> kcs, List<IEColumns> ies, List<AEColumns> aes)
        {
            var sqlBuilder = new StringBuilder();
            sqlBuilder.Append(GetDeleteCommands());
            sqlBuilder.Append(BuildUnitsSql(units));
            sqlBuilder.Append(BuildKCsSql(kcs));
            sqlBuilder.Append(BuildIEsSql(ies));
            sqlBuilder.Append(BuildAEsSql(aes));

            return sqlBuilder.ToString();
        }

        private static string GetDeleteCommands()
        {
            return @"DELETE FROM public.""Submissions"";
DELETE FROM public.""ArrangeTaskContainerSubmissions"";
DELETE FROM public.""Texts"";
DELETE FROM public.""Images"";
DELETE FROM public.""Videos"";
DELETE FROM public.""MetricRangeRules"";
DELETE FROM public.""BasicMetricCheckers"";
DELETE FROM public.""BannedWordsCheckers"";
DELETE FROM public.""RequiredWordsCheckers"";
DELETE FROM public.""ChallengeHints"";
DELETE FROM public.""ChallengeFulfillmentStrategies"";
DELETE FROM public.""Challenges"";
DELETE FROM public.""MrqItems"";
DELETE FROM public.""MultiResponseQuestions"";
DELETE FROM public.""ArrangeTaskElements"";
DELETE FROM public.""ArrangeTaskContainers"";
DELETE FROM public.""ArrangeTasks"";
DELETE FROM public.""AssessmentEvents"";
DELETE FROM public.""InstructionalEvents"";
DELETE FROM public.""KnowledgeComponents"";
DELETE FROM public.""Units"";
DELETE FROM public.""Learners"";

";
        }

        private static string BuildUnitsSql(List<UnitColumns> units)
        {
            var sqlBuilder = new StringBuilder();

            foreach (var unit in units)
            {
                sqlBuilder.Append("INSERT INTO public.\"Units\"(\"Id\", \"Code\", \"Name\", \"Description\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + unit.Id + ", '" + unit.Code + "', '"
                                  + unit.Name + "', '" + unit.Description + "');");
                sqlBuilder.AppendLine().AppendLine();
            }

            return sqlBuilder.ToString();
        }

        private static string BuildKCsSql(List<KCColumns> kcs)
        {
            var sqlBuilder = new StringBuilder();

            foreach (var kc in kcs)
            {
                sqlBuilder.Append("INSERT INTO public.\"KnowledgeComponents\"(\"Id\", \"Code\", \"Name\", \"Description\", \"UnitId\", \"ParentId\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + kc.Id + ", '" + kc.Code + "', '"
                                  + kc.Name + "', '" + kc.Description + "', "
                                  + (kc.UnitId == 0 ? "NULL" : kc.UnitId) + ", "
                                  + (kc.ParentId == 0 ? "NULL" : kc.ParentId) + ");");
                sqlBuilder.AppendLine().AppendLine();
            }

            return sqlBuilder.ToString();
        }

        private static string BuildIEsSql(List<IEColumns> ies)
        {
            var sqlBuilder = new StringBuilder();

            foreach (var ie in ies)
            {
                sqlBuilder.Append("INSERT INTO public.\"InstructionalEvents\"(\"Id\", \"KnowledgeComponentId\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + ie.Id + ", " + ie.KnowledgeComponentId + ");");
                sqlBuilder.AppendLine();
                switch (ie.Type)
                {
                    case "text": sqlBuilder.Append(BuildTextSql(ie));
                        break;
                    case "image": sqlBuilder.Append(BuildImageSql(ie));
                        break;
                    case "video": sqlBuilder.Append(BuildVideoSql(ie));
                        break;
                }
            }

            return sqlBuilder.ToString();
        }

        private static string BuildTextSql(IEColumns ie)
        {
            var sqlBuilder = new StringBuilder();
            sqlBuilder.Append("INSERT INTO public.\"Texts\"(\"Id\", \"Content\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + ie.Id + ", '" + ie.Text + "');");
            sqlBuilder.AppendLine().AppendLine();
            return sqlBuilder.ToString();
        }

        private static string BuildImageSql(IEColumns ie)
        {
            var sqlBuilder = new StringBuilder();
            sqlBuilder.Append("INSERT INTO public.\"Images\"(\"Id\", \"Url\", \"Caption\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + ie.Id + ", '" + ie.Url + "', '" + ie.Caption + "');");
            sqlBuilder.AppendLine().AppendLine();
            return sqlBuilder.ToString();
        }

        private static string BuildVideoSql(IEColumns ie)
        {
            var sqlBuilder = new StringBuilder();
            sqlBuilder.Append("INSERT INTO public.\"Videos\"(\"Id\", \"Url\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + ie.Id + ", '" + ie.Url + "');");
            sqlBuilder.AppendLine().AppendLine();
            return sqlBuilder.ToString();
        }

        private static string BuildAEsSql(List<AEColumns> aes)
        {
            var sqlBuilder = new StringBuilder();

            foreach (var ae in aes)
            {
                sqlBuilder.Append("INSERT INTO public.\"AssessmentEvents\"(\"Id\", \"KnowledgeComponentId\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + ae.Id + ", " + ae.KnowledgeComponentId + ");");
                sqlBuilder.AppendLine();
                switch (ae.Type)
                {
                    case "mrq":
                        sqlBuilder.Append(BuildMrqSql(ae));
                        break;
                    case "at":
                        sqlBuilder.Append(BuildAtSql(ae));
                        break;
                    case "wl":
                        sqlBuilder.Append(BuildWlSql(ae));
                        break;
                }
            }
            sqlBuilder.AppendLine().AppendLine();
            return sqlBuilder.ToString();
        }

        private static string BuildMrqSql(AEColumns ae)
        {
            var sqlBuilder = new StringBuilder();
            var startingItemId = ae.Id * 10; //There won't be more than 10 items per AE

            sqlBuilder.Append("INSERT INTO public.\"MultiResponseQuestions\"(\"Id\", \"Text\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + ae.Id + ", '" + ae.Text + "');");
            sqlBuilder.AppendLine();
            foreach (var mrqItem in ae.Items)
            {
                var itemParts = mrqItem.Split('\n');
                sqlBuilder.Append("INSERT INTO public.\"MrqItems\"(\"Id\", \"Text\", \"IsCorrect\", \"Feedback\", \"MrqId\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + startingItemId-- + ", '" + itemParts[0] + "', "
                                  + itemParts[1] + ", '" + itemParts[2] + "', " + ae.Id + ");");
                sqlBuilder.AppendLine();
            }

            sqlBuilder.AppendLine().AppendLine();
            return sqlBuilder.ToString();
        }

        private static string BuildAtSql(AEColumns ae)
        {
            var sqlBuilder = new StringBuilder();
            var startingContainerId = ae.Id * 10; //There won't be more than 10 containers per AT

            sqlBuilder.Append("INSERT INTO public.\"ArrangeTasks\"(\"Id\", \"Text\") VALUES");
            sqlBuilder.AppendLine();
            sqlBuilder.Append("\t(" + ae.Id + ", '" + ae.Text + "');");
            sqlBuilder.AppendLine();
            foreach (var atContainers in ae.Items)
            {
                var itemParts = atContainers.Split('\n');
                sqlBuilder.Append("INSERT INTO public.\"ArrangeTaskContainers\"(\"Id\", \"ArrangeTaskId\", \"Title\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + startingContainerId-- + ", " + ae.Id + ", '" + itemParts[0] + "');");
                sqlBuilder.AppendLine();
                sqlBuilder.Append(BuildAtElementSql(itemParts, startingContainerId+1));
            }

            sqlBuilder.AppendLine().AppendLine();
            return sqlBuilder.ToString();
        }

        private static string BuildAtElementSql(string[] itemParts, int startingContainerId)
        {
            var startingElementId = startingContainerId * 10; //There won't be more than 10 items per container
            var sqlBuilder = new StringBuilder();
            for (var i = 1; i < itemParts.Length; i+=2)
            {
                sqlBuilder.Append("INSERT INTO public.\"ArrangeTaskElements\"(\"Id\", \"ArrangeTaskContainerId\", \"Text\", \"Feedback\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + startingElementId-- + "," + startingContainerId + ", '"
                                  + itemParts[i] + "', '" + itemParts[i+1] + "');");
                sqlBuilder.AppendLine();
            }

            return sqlBuilder.ToString();
        }

        private static string BuildWlSql(AEColumns ae)
        {
            return "\n";
        }

        private static void Save(string sqlScript, string destination)
        {
            File.WriteAllText(destination, sqlScript);
        }
    }
}
