using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tutor.Infrastructure.Database.DataImport.DomainExcelModel;
using Tutor.Infrastructure.Database.DataImport.LearnerExcelModel;

namespace Tutor.Infrastructure.Database.DataImport
{
    internal static class LearnerSqlExporter
    {
        internal static string BuildSql(List<LearnerGroupsColumns> groups, DomainExcelContent domainContent)
        {
            return BuildLearnerGroupsSql(groups)
                   + BuildMasterySql(groups.SelectMany(g => g.Learners).ToList(), domainContent);
        }

        private static string BuildLearnerGroupsSql(List<LearnerGroupsColumns> groups)
        {
            var startingId = -1000;
            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendLine().AppendLine();
            foreach (var group in groups)
            {
                sqlBuilder.Append("INSERT INTO public.\"LearnerGroups\"(\"Id\", \"Name\") VALUES");
                sqlBuilder.AppendLine();
                sqlBuilder.Append("\t(" + group.Id + ", '" + group.GroupName + "');");
                sqlBuilder.AppendLine().AppendLine();

                foreach (var learner in group.Learners)
                {
                    sqlBuilder.Append("INSERT INTO public.\"Users\"(\"Id\", \"Username\", \"Password\", \"Salt\", \"Role\") VALUES");
                    sqlBuilder.AppendLine();
                    sqlBuilder.Append("\t(" + learner.Id + ", '" + learner.Index + "', '"
                                      + learner.Password + "', '" + learner.Salt + "', 2);");
                    sqlBuilder.AppendLine().AppendLine();

                    sqlBuilder.Append("INSERT INTO public.\"Learners\"(\"Id\", \"UserId\", \"Index\", \"Name\", \"Surname\") VALUES");
                    sqlBuilder.AppendLine();
                    sqlBuilder.Append("\t(" + learner.Id + ", " + learner.Id + ", '" + learner.Index + "', '"
                                      + learner.Name + "', '" + learner.Surname + "');");
                    sqlBuilder.AppendLine().AppendLine();

                    sqlBuilder.Append("INSERT INTO public.\"GroupMemberships\"(\"Id\", \"LearnerId\", \"LearnerGroupId\") VALUES");
                    sqlBuilder.AppendLine();
                    sqlBuilder.Append("\t(" + startingId++ + ", " + learner.Id + ", " + group.Id + ");");
                    sqlBuilder.AppendLine().AppendLine();
                }
            }

            return sqlBuilder.ToString();
        }

        private static string BuildMasterySql(List<UserLearnerColumns> learners, DomainExcelContent domainContent)
        {
            var sqlBuilder = new StringBuilder();
            var enrollmentId = -10000;
            var kcMasteryId = -10000;
            var aiMasteryId = -100000;
            foreach (var learnerId in learners.Select(l => l.Id))
            {
                foreach (var unit in domainContent.Units)
                {
                    sqlBuilder.Append(
                        "INSERT INTO public.\"UnitEnrollments\"(\"Id\", \"LearnerId\", \"KnowledgeUnitId\", \"Start\", \"Status\") VALUES");
                    sqlBuilder.AppendLine();
                    sqlBuilder.Append("\t(" + ++enrollmentId + ", " + learnerId + ", "
                                      + unit.Id + ", '" + DateTime.Now + "', " + 0 +");");
                    sqlBuilder.AppendLine().AppendLine();
                }
                foreach (var kcId in domainContent.KnowledgeComponents.Select(kc => kc.Id))
                {
                    sqlBuilder.Append(
                        "INSERT INTO public.\"KcMasteries\"(\"Id\", \"Mastery\", \"KnowledgeComponentId\", \"LearnerId\", \"IsPassed\", \"IsSatisfied\", \"IsCompleted\", \"HasActiveSession\") VALUES");
                    sqlBuilder.AppendLine();
                    sqlBuilder.Append("\t(" + ++kcMasteryId + ", 0.00, " + kcId + ", "
                                      + learnerId + ", false, false, false, false);");
                    sqlBuilder.AppendLine().AppendLine();

                    var assessmentItems = domainContent.AssessmentItems.Where(ai => ai.KnowledgeComponentId == kcId).OrderBy(ai => ai.Order);
                    foreach (var item in assessmentItems)
                    {
                        sqlBuilder.Append(
                            "INSERT INTO public.\"AssessmentItemMasteries\"(\"Id\", \"AssessmentItemId\", \"Mastery\", \"SubmissionCount\", \"LastSubmissionTime\", \"KnowledgeComponentMasteryId\") VALUES");
                        sqlBuilder.AppendLine();
                        sqlBuilder.Append("\t(" + aiMasteryId++ + ", " + item.Id
                                          + ", 0.00, 0, NULL, "
                                          + kcMasteryId + ");");
                        sqlBuilder.AppendLine().AppendLine();
                    }
                }
            }

            return sqlBuilder.ToString();
        }
    }
}