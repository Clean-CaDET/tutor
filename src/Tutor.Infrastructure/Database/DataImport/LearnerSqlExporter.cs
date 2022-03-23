using System;
using System.Collections.Generic;
using System.Text;
using Tutor.Infrastructure.Database.DataImport.DomainExcelModel;

namespace Tutor.Infrastructure.Database.DataImport
{
    internal class LearnerSqlExporter
    {
        internal static string BuildSql(List<LearnerColumns> learners, List<KCColumns> kcs)
        {
            return BuildLearnerSql(learners) + BuildMasterySql(learners, kcs);
        }

        private static string BuildLearnerSql(List<LearnerColumns> learners)
        {
            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendLine().AppendLine();
            foreach (var learner in learners)
            {
                sqlBuilder.Append("INSERT INTO public.\"Learners\"(\"Id\", \"StudentIndex\", \"Password\", \"Salt\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + learner.Id + ", '" + learner.StudentIndex + "', '"
                                  + learner.Password + "', '" + learner.Salt + "');");
                sqlBuilder.AppendLine().AppendLine();
            }

            return sqlBuilder.ToString();
        }

        private static string BuildMasterySql(List<LearnerColumns> learners, List<KCColumns> kcs)
        {
            var sqlBuilder = new StringBuilder();
            var startingId = -100000;
            foreach (var learner in learners)
            {
                foreach (var kc in kcs)
                {
                    sqlBuilder.Append(
                        "INSERT INTO public.\"KcMastery\"(\"Id\", \"Mastery\", \"KnowledgeComponentId\", \"LearnerId\", \"IsPassed\", \"IsSatisfied\") VALUES");
                    sqlBuilder.AppendLine();
                    sqlBuilder.Append("\t(" + startingId++ + ", 0.00, " + kc.Id + ", "
                                      + learner.Id + ", false, false);");
                    sqlBuilder.AppendLine().AppendLine();
                }
            }

            return sqlBuilder.ToString();
        }
    }
}